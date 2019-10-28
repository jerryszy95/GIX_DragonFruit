using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estInput : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody RB;
    GameObject Camera;
    bool initial = true;
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        Camera = GameObject.Find("First Person Camera");
        transform.rotation = Camera.transform.rotation;
        RB.useGravity = false;
    }

    // Update is called once per frame
    void Update()  
    {  
        int touchNum = Input.touchCount;  
  
        if (touchNum > 0)  
        {  
            Touch touch = Input.GetTouch(0);  
            if (touch.phase == TouchPhase.Moved)  
            {
                RB.useGravity = true;
                RB.AddRelativeForce(new Vector3(0f,1.2f,0.5f),ForceMode.Impulse);
                // Vector3 dir = new Vector3(touch.deltaPosition.x, touch.deltaPosition.y, 0f) * 0.1f;  
                // transform.Translate(dir);  
                initial = false;
                return;
            }
        }
        
        if (initial)
        {
            transform.rotation = Camera.transform.rotation;
            transform.position = Camera.transform.position + Camera.transform.forward;
        }
    }
}
