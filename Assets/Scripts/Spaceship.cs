using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spaceship : MonoBehaviour {

    public GameObject moonObj, earthObj, gmObj;
    public float angle = 0;
    public float dVstart = 5;
    public GameManager gm;
    public Text currentV, dMoonText, dEarthText, timeText;

    private Rigidbody csmRB;
    private float angle_rad;
    private Vector3 r_moon, r_earth;
    private float d_moon, d_earth, simTime;
    private int dd, hh, mm;
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

        currentV.text =  "Hast.: "+csmRB.velocity.magnitude.ToString("0");
        dMoonText.text = "Afst. til Månen: " + (d_moon*100).ToString("0");
        dEarthText.text = "Afst. til Jorden: " + (d_earth * 100).ToString("0");

        simTime = Time.timeSinceLevelLoad * 10000;
        dd = Mathf.FloorToInt(simTime / 86400);
        hh = Mathf.FloorToInt((simTime - 86400 * dd) / 3600);
        mm = Mathf.FloorToInt((simTime - 86400 * dd - 3600 *hh) / 60);

        timeText.text = "Tid: " + dd + "d" + hh + ":" + mm;
        

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

        if (d_moon < 900)
        {
            Time.timeScale = d_moon / 900f * pause;
            Time.fixedDeltaTime = 0.002f * Time.timeScale;
        }
        else
        {
            Time.timeScale = 1 * pause;
            Time.fixedDeltaTime = 0.02f * pause;
        }

        r_earth = earthObj.transform.position - transform.position;
        d_earth = r_earth.magnitude;

        if (d_earth < 900)
        {
            Time.timeScale = d_earth / 900f * pause;
            Time.fixedDeltaTime = 0.002f * Time.timeScale;
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

    public void RetroBurn()
    {
        csmRB.AddForce(-csmRB.velocity);
    }

    void initShip()
    {
        dVstart = gm.startVelocity;
        angle = gm.startAngle;
        angle_rad = (float)(-(angle-90) / 180 * 3.14);
        csmRB.transform.position = new Vector3(Mathf.Cos(angle_rad) * 66, 0, Mathf.Sin(angle_rad) * 66);
        csmRB.velocity = new Vector3(-Mathf.Sin(angle_rad) * dVstart, 0, Mathf.Cos(angle_rad) * dVstart);
        initShipDone = (gm.startVelIsSet && gm.startAngIsSet);
    }

   
}
