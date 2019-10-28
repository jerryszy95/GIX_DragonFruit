using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GoalDetecter : MonoBehaviour
{
    int count = 0;
    private void OnTriggerEnter(Collider other)
    {
        count++;
        GameObject.Find("Goal").GetComponent<Text>().text = "Goal: " + count.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
