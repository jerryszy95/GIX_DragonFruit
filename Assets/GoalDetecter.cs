using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GoalDetecter : MonoBehaviour
{
    int count = 0;
    Animator anim;

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("LevelUp0")){
            Debug.Log("trigger");
            count++;
            TriggerJumpActions();
            BreakFruit fruit = other.transform.GetComponent<BreakFruit>();
            if (fruit != null)
            {
                fruit.Run();
            }
            transform.Find("Score").GetComponent<TextMesh>().text = "Goal: " + count.ToString();
        }
        
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            //Debug.Log("Trigger");
            count++;
            TriggerJumpActions();
            BreakFruit fruit = other.transform.GetComponent<BreakFruit>();
            if (fruit != null)
            {
                fruit.Run();
            }
            transform.Find("Score").GetComponent<TextMesh>().text = "Goal: " + count.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            TriggerJumpActions();
    }

    void TriggerJumpActions()
    {
        anim.SetTrigger("Jump");
    }
}
