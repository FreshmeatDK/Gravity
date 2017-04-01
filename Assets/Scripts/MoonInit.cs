using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonInit : MonoBehaviour {

    private Rigidbody moonRB;

	// Use this for initialization
	void Start () {
        moonRB = GetComponent<Rigidbody>();
        moonRB.velocity = new Vector3(-101.755f, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
