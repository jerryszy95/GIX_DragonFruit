using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore.Examples.CloudAnchors;

public class ScoreController : MonoBehaviour
{
    private int score = 0;
    public GameObject WinUI;
    
    public bool isDragonReady()
    {
        if (GameObject.Find("Mouse Drago Simple(Clone)") != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragonReady())
        {
            score = GameObject.Find("Mouse Drago Simple(Clone)").GetComponent<GoalDetecter>().count;
            if (score >= 5)
            {
                GameObject.Find("CloudAnchorsExampleController").GetComponent<CloudAnchorsExampleController>().PopIsOn();
                WinUI.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
