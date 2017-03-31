using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthInit : MonoBehaviour {

    private Rigidbody earthRB;

    // Use this for initialization
	void Start () {

        earthRB = GetComponent<Rigidbody>();
        earthRB.velocity = new Vector3(0.0126f,0f,0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
