using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotateY : MonoBehaviour {
	public float speed = 0.2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0,speed,0));
	}
}
