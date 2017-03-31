using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject csmObj, moonObj;

    private Vector3 camPos,r;

	// Use this for initialization
	void Start () {
        transform.Rotate(90, 0, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        r = csmObj.transform.position - moonObj.transform.position;
        camPos.x = (csmObj.transform.position.x+moonObj.transform.position.x)/2;
        camPos.z = (csmObj.transform.position.z + moonObj.transform.position.z) / 2;
        camPos.y = r.magnitude+12;

        transform.position = camPos;
        
        	
	}
}
