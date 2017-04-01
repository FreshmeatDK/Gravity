using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csmMarkerController : MonoBehaviour {

    public GameObject csmObj;
    private Vector3 csmMarkerPos;

    // Use this for initialization
    void Start()
    {
        //csmMarkerPos.x = csmObj.transform.position.x / 384 * 140+150;
        //csmMarkerPos.y = csmObj.transform.position.z / 384 * 140+150;
        csmMarkerPos.x = 50;
        csmMarkerPos.y = 50;
        csmMarkerPos.z = 1;
        transform.position = csmMarkerPos;

    }

    // Update is called once per frame
    void Update()
    {

        csmMarkerPos.x = csmObj.transform.position.x / 3840 * 140 + 150;
        csmMarkerPos.y = csmObj.transform.position.z / 3840 * 140 + 150;
        //csmMarkerPos.x = 50;
        //csmMarkerPos.y = 50;

        csmMarkerPos.z = 1;
        transform.localPosition = csmMarkerPos;

    }
}
