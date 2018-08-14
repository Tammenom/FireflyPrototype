﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour {

    public GameObject MRacer;
    public HoverMotor MHM;
    private string MRState;

    public ParticleSystem rT;
    public ParticleSystem lT;
    public ParticleSystem rbT;
    public ParticleSystem lbT;
    public ParticleSystem rBoost;
    public ParticleSystem lBoost;

    private float tBSpeed;
    private float tBLife;
    private float tBAcc;
    private float tBSlow;
    private float tBLA;
    private float tBLS;
    private float tBSpeedB;
    private float tBLifeB;
    private bool tOnBoost;
    







    // Use this for initialization
    void Start () {
        MHM = MRacer.GetComponent<HoverMotor>();
        
         tBSpeedB =10;
         tBLifeB = 0.4f;
        tBSpeed = 0;
        tBLife = 0;
        tBAcc = 0.5f;
        tBLA = 0.02f;
        tBSlow = 0.0125f;
        tBLS = 0.005f;
        
    }
	
	// Update is called once per frame

	void Update () {
        rbT.startSpeed = tBSpeed;
        lbT.startSpeed = tBSpeed;
        rbT.startLifetime = tBLife;
        lbT.startLifetime = tBLife;
        tOnBoost = MHM.onBoost;

        MRState = MHM.racerState;

        

        switch (MRState)
        {

            case("acc"):
                {
                    rbT.Play();
                    lbT.Play();
                    if (tBSpeed < tBSpeedB)
                    {
                        tBSpeed = tBSpeed + tBAcc;
                    }

                    if(tBLife < tBLifeB)
                    {
                        tBLife = tBLife + tBLA;
                    }

                }
                break;

            case ("slow"):
                {
                    if (tBSpeed > 0)
                    {
                        tBSpeed = tBSpeed - tBSlow;
                    }

                    if (tBLife > 0)
                    {
                        tBLife = tBLife - tBLS;
                    }

                }
                break;

            case ("stand"):
                {
                    if (tBSpeed > 0)
                    {
                        tBSpeed = tBSpeed - tBSlow;
                    }

                    if (tBLife > 0)
                    {
                        tBLife = tBLife - tBLS;
                    }
                }
                break;
            case ("default"):
                {

                    rbT.Stop();
                    lbT.Stop();
                }
                break;

               

        }
        if (tOnBoost)
        {
            lBoost.Play();
            rBoost.Play();
            rbT.Stop();
            lbT.Stop();

        }
        else
        {
            lBoost.Stop();
            rBoost.Stop();
            rbT.Play();
            lbT.Play();
        }
    }
}
