using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleARCore.Examples.CloudAnchors;

public class RingColliderController : MonoBehaviour
{
    private bool ringTriggered = false;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (ringTriggered)
        {
            GameObject.Find("CloudAnchorsExampleController").GetComponent<CloudAnchorsExampleController>().RingIsTriggered();
        }
        else
        {
            GameObject.Find("CloudAnchorsExampleController").GetComponent<CloudAnchorsExampleController>().RingIsNotTriggered();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
       //GameObject.Find("DebugUIText").GetComponent<Text>().text = GameObject.Find("DebugUIText").GetComponent<Text>().text + "\n" + "On Trigger Enter";
       //GameObject.Find("DebugUIText").GetComponent<Text>().text = GameObject.Find("DebugUIText").GetComponent<Text>().text + "\n" + other.tag;
       //GameObject.Find("DebugUIText").GetComponent<Text>().text = GameObject.Find("DebugUIText").GetComponent<Text>().text + "\n" + other.name;
        if (other.CompareTag("Localplayer"))
        {
            //GameObject.Find("DebugUIText").GetComponent<Text>().text = GameObject.Find("DebugUIText").GetComponent<Text>().text + "\n" + "The ring UI is on";
            GameObject.Find("CloudAnchorsExampleController").GetComponent<CloudAnchorsExampleController>().BeaconActived();
            Debug.Log("triggered");
            ringTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //GameObject.Find("DebugUIText").GetComponent<Text>().text = GameObject.Find("DebugUIText").GetComponent<Text>().text + "\n" + "On Trigger Exit";
        //GameObject.Find("DebugUIText").GetComponent<Text>().text = GameObject.Find("DebugUIText").GetComponent<Text>().text + "\n" + other.tag;
        //GameObject.Find("DebugUIText").GetComponent<Text>().text = GameObject.Find("DebugUIText").GetComponent<Text>().text + "\n" + other.name;
        if (other.CompareTag("Localplayer"))
        {
            GameObject.Find("CloudAnchorsExampleController").GetComponent<CloudAnchorsExampleController>().BeaconDisabled();
            Debug.Log("Not triggered");
            //GameObject.Find("DebugUIText").GetComponent<Text>().text = GameObject.Find("DebugUIText").GetComponent<Text>().text + "\n" + "The ring UI is off";
            ringTriggered = false;
        }
    }

}
