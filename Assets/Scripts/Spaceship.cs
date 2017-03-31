using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spaceship : MonoBehaviour {

    public GameObject moonObj, gmObj;
    public float angle = 0;
    public float dVstart = 5;
    public GameManager gm;
    public Text currentV, currentA;

    private Rigidbody csmRB;
    private float angle_rad;
    private Vector3 r_moon;
    private float d_moon;
    private int pause;
    private bool initShipDone;
    private Quaternion csmRotation;
    private float csmAngle; // current angle to z-axis

    // Use this for initialization
    void Start () {
        csmRB = GetComponent<Rigidbody>();
        
        gm.GetComponent<GameManager>();
        initShipDone = false;
                
    }
	
	// Update is called once per frame
	void Update () {

        if ((!initShipDone) && gm.startAngIsSet && gm.startVelIsSet)
        {
            initShip();
        }

        currentV.text = csmRB.velocity.magnitude.ToString();
        currentA.text = angle.ToString();

        if (gm.pause || !initShipDone)
        {
            pause = 0;
        }
        else
        {
            pause = 1;
        }

        r_moon = moonObj.transform.position - transform.position;
        d_moon = r_moon.magnitude;

        if (d_moon < 9)
        {
            Time.timeScale = d_moon / 10f * pause;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
        else
        {
            Time.timeScale = 1 * pause;
            Time.fixedDeltaTime = 0.02f * pause;
        }

        
	}

    private void FixedUpdate()
    {
        csmRotation = Quaternion.LookRotation(csmRB.velocity);
        transform.rotation = csmRotation;
    }

    void initShip()
    {
        dVstart = gm.startVelocity;
        angle = gm.startAngle;
        angle_rad = (float)(angle / 180 * 3.14);
        csmRB.transform.position = new Vector3(Mathf.Cos(angle_rad) * 3, 0, Mathf.Sin(angle_rad) * 3);
        csmRB.velocity = new Vector3(-Mathf.Sin(angle_rad) * dVstart, 0, Mathf.Cos(angle_rad) * dVstart);
        initShipDone = (gm.startVelIsSet && gm.startAngIsSet);
    }
}
