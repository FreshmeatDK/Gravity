using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravIndicatorController : MonoBehaviour {

    public GameObject body;

    private Vector3 f_g;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GravInteract gravia = body.GetComponent<GravInteract>();
        transform.position = body.transform.position + 3 * gravia.f_g_vec;
	}
}
