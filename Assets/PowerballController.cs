using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore.Examples.CloudAnchors;

public class PowerballController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickButton()
    {
        GameObject.Find("LocalPlayer").GetComponent<LocalPlayerController>().enpowerDragonFruit();
    }
}
