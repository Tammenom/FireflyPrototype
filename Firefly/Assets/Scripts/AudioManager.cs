using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour {

    public AudioSource boost;
    public AudioSource accel;
    public AudioSource turbine;
    public AudioSource airbreak;
    public AudioSource alarmsound;
    public AudioSource shildCollision;
    public AudioSource turbineLeft;
    public AudioSource turbineRight;

    /* public AudioSource backTurbine;
     public AudioSource shipBreak;
     public AudioSource shipAirBreak;
     public AudioSource acceleration;
     public AudioSource shipRotation;*/

    public HoverMotor MHM;
    public ShildController SCtrl;
    public GameObject MRacer;
    public EnergyController MEC;
    public ShildController MSC;
    public AudioClip booster;
    public AudioClip accerleration;
    public AudioClip airbreaking;
    public AudioClip shildImpact;
    private bool boostPlayed;
    private bool accPlayed;
    private bool airbreakPlayed;
    private bool shildPlayed;
    private float turbineMax;
    // Use this for initialization
    void Start () {
        MEC = MRacer.GetComponent<EnergyController>();
        MSC = MRacer.GetComponent<ShildController>();
        MHM = MRacer.GetComponent<HoverMotor>();
        boost.Pause();
        boostPlayed = false;
        accPlayed = false;
        airbreakPlayed = false;
        shildPlayed = false;
}

// Update is called once per frame
void FixedUpdate () {

        if (MHM.onBoost)
        {
            if (!boostPlayed) {
                boost.volume = 1;
                boost.PlayOneShot(booster, 1); }

            boostPlayed = true; 
        }
        else
        {
            boost.volume = boost.volume - (Time.deltaTime);
            boostPlayed = false;
        }


        if(MHM.racerState == "acc")
        {
            if (!accPlayed)
            {
                accel.volume = 0.1f;
                accel.PlayOneShot(accerleration, 1);
            }

            accPlayed = true;
        }
    
        else
        {
            accel.volume = accel.volume - (Time.deltaTime/2);
            accPlayed = false;
        }


        if (MHM.racerState == "acc")
        {
            turbineMax = (MHM.speed / 600);
            if(turbine.volume < turbineMax)
            {
                turbine.volume = turbine.volume + (Time.deltaTime / 6);
            } 

        }

        else
        {
            turbine.volume = turbine.volume - (Time.deltaTime / 2);
            
        }

        if (MHM.airbreak)
        {

            if (!airbreakPlayed)
            {
                airbreak.volume = MHM.speed / 500;
                airbreak.PlayOneShot(airbreaking, 0.3f);
            }

            airbreakPlayed = true;
            
        }else
        { airbreakPlayed = false; }


        if (MSC.shildLevel < 80)
        {

            alarmsound.volume = 1 - ((MSC.shildLevel / 200f) + 0.5f);

        }
        else { alarmsound.volume = 0; }

        if (MSC.impact)
        {

            if (!shildPlayed)
            {
                shildCollision.volume = MHM.speed/250;
                shildCollision.PlayOneShot(shildImpact, 0.3f);
            }

            shildPlayed = true;

        }
        else
        { shildPlayed = false; }


        turbineLeft.volume = (MHM.speed / 400) -0.15f;
        turbineRight.volume = (MHM.speed / 400) -0.10f;
    }
}
