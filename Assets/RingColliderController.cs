using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore.Examples.CloudAnchors;

public class RingColliderController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Localplayer"))
        {
            GameObject.Find("CloudAnchorsExampleController").GetComponent<CloudAnchorsExampleController>().BeaconActived();
        }
    }
}
