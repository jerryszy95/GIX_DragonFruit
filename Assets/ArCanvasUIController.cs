using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleARCore.Examples.CloudAnchors;

public class ArCanvasUIController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ringUI;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("CloudAnchorsExampleController").GetComponent<CloudAnchorsExampleController>().getRingStatus())
        {
            // if the ring status is true (Triggered), set ringUI inactive
            //GameObject.Find("DebugUIText").GetComponent<Text>().text = GameObject.Find("DebugUIText").GetComponent<Text>().text + "\n" + "RingUI set active";

            ringUI.SetActive(true);
        }
        else
        {
            // if the ring status is false (notTrigger), set ringUI active
            //GameObject.Find("DebugUIText").GetComponent<Text>().text = GameObject.Find("DebugUIText").GetComponent<Text>().text + "\n" + "RingUI set inactive";
            ringUI.SetActive(false);
        }
    }
}
