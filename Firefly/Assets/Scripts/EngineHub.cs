using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EngineHub : MonoBehaviour {

    public ShildController MSC;
    public BoostController MBC;
    public SideEngineController MSEC;

    public GameObject MRacer;

    public Graphic sideIcon;
    public Graphic shildIcon;
    public Graphic boostIcon;

    public Graphic sideBack;
    public Graphic shildBack;
    public Graphic boostBack;


    public float sEFac;
    public float shildFac;
    public float boostFac;
    public Color sEColor;
    public Color shildColor;
    public Color boostColor;

    public float shildAlarm;
    public bool salarm;
    


    // Use this for initialization
    void Start () {

        MSC = MRacer.GetComponent<ShildController>();
        MBC = MRacer.GetComponent<BoostController>();
        MSEC = MRacer.GetComponent<SideEngineController>();
        shildAlarm = 1f;
        salarm = false;
}

// Update is called once per frame
void FixedUpdate () {

        sEFac = 0.0007f * MSEC.SELevel;
        shildFac = 0.00075f * MSC.shildLevel;
        boostFac = 0.00075f * MBC.eLevel;

        if (MSC.shildLevel < 80f)
        {
            if (shildAlarm <= 1f&&!salarm) { shildAlarm = shildAlarm + Time.deltaTime;  }
            if (shildAlarm >= 1f && !salarm) { salarm = true; }
            if (shildAlarm >= 0.5f && salarm) { shildAlarm = shildAlarm - Time.deltaTime;  }
            if (shildAlarm <= 0.5f && salarm) { salarm = false; }

        }
        else
        {
            shildAlarm = 1f;
        }

        sEColor = Color.HSVToRGB(sEFac, 0.7f, 1f, false);
        shildColor = Color.HSVToRGB(shildFac, 0.7f, shildAlarm, false); 
        boostColor = Color.HSVToRGB(boostFac, 0.7f, 1f, false); 
        sEColor.a = 0.6f;
        shildColor.a = 0.6f;
        boostColor.a = 0.6f;

        


        sideIcon.color = sEColor;
        shildIcon.color = shildColor;
        boostIcon.color = boostColor;
        sideBack.color = sEColor; 
        shildBack.color = shildColor; ;
        boostBack.color = boostColor; ;


        


}
}
