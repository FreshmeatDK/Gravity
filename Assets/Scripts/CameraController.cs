using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject csmObj, moonObj, earthObj;

    private Vector3 camPos,r_m, r_e;

	// Use this for initialization
	void Start () {
        transform.Rotate(0, 0, 0);
        transform.position = new Vector3(csmObj.transform.position.x, 70, csmObj.transform.position.z);
	}
	
	// Update is called once per frame
	void Update ()
    {
        r_m = csmObj.transform.position - moonObj.transform.position;
        r_e = csmObj.transform.position - earthObj.transform.position;

        if (r_e.sqrMagnitude > r_m.sqrMagnitude)
        {
            camPos.x = (csmObj.transform.position.x + moonObj.transform.position.x) / 2;
            camPos.z = (csmObj.transform.position.z + moonObj.transform.position.z) / 2;
            camPos.y = r_m.magnitude*2 +  80;
        }
        else
        {
            camPos.x = (csmObj.transform.position.x + earthObj.transform.position.x) / 2;
            camPos.z = (csmObj.transform.position.z + earthObj.transform.position.z) / 2;
            camPos.y = r_e.magnitude*2 + 80;
        }

        transform.position = camPos;
                        	
	}
}
