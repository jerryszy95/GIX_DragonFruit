using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CollectBall : MonoBehaviour
{
    // Start is called before the first frame update
    int ballcount = 0;
    public void addball()
    {
        ballcount++;
    }
    public void removeball()
    {
        ballcount--;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("RemainingBall").GetComponent<Text>().text = "RemainingBall: " + ballcount.ToString();
    }
}
