using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GoalDetecter : MonoBehaviour
{
    public Text GoalText;
    int Goal = 0;
    // Start is called before the first frame update
    void Start()
    {
        GoalText.text = "Goal：0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
