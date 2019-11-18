using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class beaconOutput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        int B1data = GameObject.Find("Beacon").GetComponent<ScannerTestScript>().rssi1;
        BluetoothLEHardwareInterface.Log("B1" + B1data);
        int B2data = GameObject.Find("Beacon").GetComponent<ScannerTestScript>().rssi2;
        BluetoothLEHardwareInterface.Log("B2" + B2data);
        int B3data = GameObject.Find("Beacon").GetComponent<ScannerTestScript>().rssi3;
        BluetoothLEHardwareInterface.Log("B3" + B3data);

        

        GameObject.Find("B1").GetComponent<Text>().text = "B1 = " + B1data.ToString();
        GameObject.Find("B2").GetComponent<Text>().text = "B2 = " + B2data.ToString();
        GameObject.Find("B3").GetComponent<Text>().text = "B3 = " + B3data.ToString();




        //////////////////////////
        string DebugStr = GameObject.Find("Beacon").GetComponent<ScannerTestScript>().DebugStr;
        GameObject.Find("DebugUI").GetComponent<Text>().text = DebugStr;


  

    }
}
