using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using GoogleARCore.Examples.CloudAnchors;

public class CollectBall : MonoBehaviour
{
    // Start is called before the first frame update
    int ballcount = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ballcount = GameObject.Find("CloudAnchorsExampleController").GetComponent<CloudAnchorsExampleController>().getDragonFruitNum();
        GameObject.Find("RemainingBall").GetComponent<Text>().text = "RemainingBall: " + ballcount.ToString();
    }
}
