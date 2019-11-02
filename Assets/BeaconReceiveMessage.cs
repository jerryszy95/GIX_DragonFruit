using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeaconReceiveMessage : MonoBehaviour
{
    void UpdateButtonText(string str)
    {
        GameObject.Find("BeaconMessage").GetComponent<Text>().text 
            = GameObject.Find("BeaconMessage").GetComponent<Text>().text + "\n" + str;
    }

    void UpdateBeaconText(string str)
    {
        GameObject.Find("BeaconMessage").GetComponent<Text>().text
            = GameObject.Find("BeaconMessage").GetComponent<Text>().text + "\n" + str;
    }
}
