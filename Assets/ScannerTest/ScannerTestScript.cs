using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;

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
                        
                        if (_latestRSSI.Max() <= -75)
                        {
                            Pop1.SetActive(false);
                            Pop2.SetActive(false);
                            Pop3.SetActive(false);
                            InstructionUI.SetActive(true);
                        }
                        else
                        {
                            int rssiMax = Enumerable.Range(0, _rssiCount).Where(j => _latestRSSI[j] == _latestRSSI.Max()).First();
                            switch (rssiMax)
                            {
                                case 0:
                                    Pop1.SetActive(true);
                                    InstructionUI.SetActive(false);
                                    break;
                                case 1:
                                    Pop2.SetActive(true);
                                    InstructionUI.SetActive(false);
                                    break;
                                case 2:
                                    Pop3.SetActive(true);
                                    InstructionUI.SetActive(false);
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
    }
}
