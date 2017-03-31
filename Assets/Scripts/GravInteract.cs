using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravInteract : MonoBehaviour {

    public Vector3 f_g_vec;

    private float g = 0.0667f;

    private GameObject[] bodies;
    private Rigidbody thisRB, otherRB;
    private Vector3 r_vec;
    private float r2;
                
	// Use this for initialization
	void Start () {
        thisRB = GetComponent<Rigidbody>();
       
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        f_g_vec.Set(0f, 0f, 0f);
        bodies = GameObject.FindGameObjectsWithTag("hasMass");
        foreach (GameObject body in bodies)
        {
            otherRB = body.GetComponent<Rigidbody>();
            r_vec = otherRB.transform.position - thisRB.transform.position;
            r2 = Vector3.Dot(r_vec, r_vec);
            if ( r2 > 0.005)
            {
                
                f_g_vec = f_g_vec + g * otherRB.mass * thisRB.mass /r2 * r_vec.normalized;
                thisRB.AddForce(f_g_vec);
            }
            
        }
	}
}
