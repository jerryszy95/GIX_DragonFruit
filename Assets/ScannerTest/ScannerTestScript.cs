using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;
using GoogleARCore.Examples.CloudAnchors;

public class ScannerTestScript : MonoBehaviour
{
    public GameObject ScannedItemPrefab;

    private float _timeout;
    private float _startScanTimeout = 10f;
    private float _startScanDelay = 0.5f;
    private bool _startScan = true;
    private Dictionary<string, ScannedItemScript> _scannedItems;

    private const int _rssiCount = 3;
    private int[] _latestRSSI = new int[_rssiCount];
  

    public string name1 = "DF_B1";
    public int rssi1 => _latestRSSI[0];

    public string name2 = "DF_B2";
    public int rssi2 => _latestRSSI[1];

    public string name3 = "DF_B3";
    public int rssi3 => _latestRSSI[2];


    public GameObject Pop1;
    public GameObject Pop2;
    public GameObject Pop3;
    public GameObject InstructionUI;
    public GameObject CongratUI;

    bool pop1status = true;
    bool pop2status = true;
    bool pop3status = true;
    bool DestoryBeacon = false;

    public void DestoryBeaconMode()
    {
        if(!pop1status && !pop2status && !pop3status)//当三个beacon都是False的情况下，Destory beacon gameobject
        {
            DestoryBeacon = true;
            InstructionUI.SetActive(false);
        }
    }


    public void OnButton()
    {
        BluetoothLEHardwareInterface.DeInitialize(() => Debug.Log("Deinitialized"));
    }

    public void OnStopScanning()
    {
        BluetoothLEHardwareInterface.Log("**************** stopping");
        BluetoothLEHardwareInterface.StopScan();
    }

    // Use this for initialization
    void Start()
    {
        for(int i = 0; i < _rssiCount; ++i)
        {
            _latestRSSI[i] = int.MinValue;
        }

        BluetoothLEHardwareInterface.Log("Start");
        _scannedItems = new Dictionary<string, ScannedItemScript>();

        BluetoothLEHardwareInterface.Initialize(true, false, () => {

            _timeout = _startScanDelay;
        },
        (error) => {

            BluetoothLEHardwareInterface.Log("Error: " + error);

            if (error.Contains("Bluetooth LE Not Enabled"))
                BluetoothLEHardwareInterface.BluetoothEnable(true);
        });
    }


    // Update is called once per frame
    void Update()
    {
        if (_timeout > 0f)
        {
            _timeout -= Time.deltaTime;
            if (_timeout <= 0f)
            {
                if (_startScan)
                {
                    _startScan = false;
                    _timeout = _startScanTimeout;

                    BluetoothLEHardwareInterface.ScanForPeripheralsWithServices(null, null, (address, name, rssi, bytes) => {
                        int i = 0;

                        if (!name.Contains("DF_B") || !int.TryParse(name.Substring(4 + name.IndexOf("DF_B"), 1), out i))
                        {
                            return;
                        }

                        i -= 1;
                  
                        if (i < 0 || i >= _rssiCount)
                        {
                            return;
                        }
                        
                        _latestRSSI[i] = rssi;
                        
                        if (_latestRSSI.Max() <= -80)
                        {
                            Pop1.SetActive(false);
                            Pop2.SetActive(false);
                            Pop3.SetActive(false);
                            InstructionUI.SetActive(true);
                            GameObject.Find("CloudAnchorsExampleController").GetComponent<CloudAnchorsExampleController>().BeaconDisabled();
                        }
                        else
                        {
                            int rssiMax = Enumerable.Range(0, _rssiCount).Where(j => _latestRSSI[j] == _latestRSSI.Max()).First();
                            switch (rssiMax)
                            {
                                case 0:
                                    if (!pop1status)
                                    {
                                        break;
                                    }
                                    Pop1.SetActive(true);
                                    //// Test function - show distance between beacon and player
                                    //float distance1 = (GameObject.Find("PlayerCamera").transform.position - GameObject.Find("TestBeacon").transform.position).magnitude;
                                    //GameObject.Find("BeaconTestText").GetComponent<Text>().text = GameObject.Find("BeaconTestText").GetComponent<Text>().text + "\n" + "B1 Distance: " + distance1;
                                    ///////////////////////////////////////////////////////////
                                    InstructionUI.SetActive(false);
                                    GameObject.Find("CloudAnchorsExampleController").GetComponent<CloudAnchorsExampleController>().BeaconActived();
                                    break;
                                case 1:
                                    if (!pop2status)
                                    {
                                        break;
                                    }
                                    Pop2.SetActive(true);
                                    //// Test function - show distance between beacon and player
                                    //float distance2 = (GameObject.Find("PlayerCamera").transform.position - GameObject.Find("TestBeacon").transform.position).magnitude;
                                    //GameObject.Find("BeaconTestText").GetComponent<Text>().text = GameObject.Find("BeaconTestText").GetComponent<Text>().text  +  "\n" + "B2 Distance: " + distance2;
                                    ///////////////////////////////////////////////////////////
                                    InstructionUI.SetActive(false);
                                    GameObject.Find("CloudAnchorsExampleController").GetComponent<CloudAnchorsExampleController>().BeaconActived();
                                    break;
                                case 2:
                                    if (!pop3status)
                                    {
                                        break;
                                    }
                                    Pop3.SetActive(true);
                                    //// Test function - show distance between beacon and player
                                    //float distance3 = (GameObject.Find("PlayerCamera").transform.position - GameObject.Find("TestBeacon").transform.position).magnitude;
                                    //GameObject.Find("BeaconTestText").GetComponent<Text>().text = GameObject.Find("BeaconTestText").GetComponent<Text>().text + "\n" + "B3 Distance: " + distance3;
                                    ///////////////////////////////////////////////////////////
                                    InstructionUI.SetActive(false);
                                    GameObject.Find("CloudAnchorsExampleController").GetComponent<CloudAnchorsExampleController>().BeaconActived();
                                    break;
                            }
                        }
                    }, true);
                }
                else
                {
                    BluetoothLEHardwareInterface.StopScan();
                    _startScan = true;
                    _timeout = _startScanDelay;
                }
            }
        }
        if (DestoryBeacon)
        {
            Debug.Log("Beacon mode is off");
            InstructionUI.SetActive(false);
            CongratUI.SetActive(true);
            Destroy(gameObject);
        }
    }

    public void Pop1Off()
    {
        pop1status = false;
    }

    public void Pop2Off()
    {
        pop2status = false;
    }

    public void Pop3Off()
    {
        pop3status = false;
    }
}
