using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public float startVelocity;
    public bool startVelIsSet = false;
    public float startAngle;
    public bool startAngIsSet = false;
    public bool pause = true;
    public Text pausetext, startV, startA;

    public void Awake()
    {
        pause = true;
        startVelIsSet = false;
        startAngIsSet = false;
        pausetext.text = "Indtast hastighed og vinkel til månen og tryk 'Go'";
    }

    public void GetVelocityInput(string value)
    {
        float.TryParse(value, out startVelocity);
        startVelIsSet = true;

        
    }

    public void GetAngleInput(string value)
    {
        float.TryParse(value, out startAngle);
        startAngIsSet = true;

    }

    public void GetGo()
    {
        pause = !pause;
        if (pause)
        {
            pausetext.text = "pause";
        }
        else
        {
            pausetext.text = "";
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
