using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoonMarkerController : MonoBehaviour {

    public GameObject moonObj;
    private Vector3 moonMarkerPos;

	// Use this for initialization
	void Start () {
        //csmMarkerPos.x = csmObj.transform.position.x / 384 * 140+150;
        //csmMarkerPos.y = csmObj.transform.position.z / 384 * 140+150;
        moonMarkerPos.x = 50;
        moonMarkerPos.y = 50;
        moonMarkerPos.z = 1;
        transform.position = moonMarkerPos;
        
	}
	
	// Update is called once per frame
	void Update () {

        moonMarkerPos.x = moonObj.transform.position.x / 3840 * 140+150;
        moonMarkerPos.y = moonObj.transform.position.z / 3840 * 140+150;
        //csmMarkerPos.x = 50;
        //csmMarkerPos.y = 50;
        
        moonMarkerPos.z = 1;
        transform.localPosition = moonMarkerPos;

    }
}
