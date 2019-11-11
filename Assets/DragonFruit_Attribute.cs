using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFruit_Attribute : MonoBehaviour
{
    Rigidbody RB;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        RB.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
