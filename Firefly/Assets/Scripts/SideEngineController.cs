using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideEngineController : MonoBehaviour {

    
    public float timeBooster = 0.5f;
    public float SELevel;
    public float SELevelMax;
    public float SERegV;
    public float SEFac;
    public bool SEActive;
    private float energyLevel;
    private bool hasEnergy;
    public bool Regenerate;
    //public Slider SESlider;
    public float sideSpeedBasic = 25f;
    public float sideSpeedTurbo = 40f;
    public float sideSpeed;
    public bool hEnergy;

    
    public RectTransform SEHub;

    public GameObject MRacer;
    public HoverMotor MHM;
    public EnergyController MEC;
    //public RectTransform eHub;

    // Use this for initialization
    void Start () {

        hEnergy = true;
        MHM = MRacer.GetComponent<HoverMotor>();
        MEC = MRacer.GetComponent<EnergyController>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        SELevelMax = 600;
        SEActive = MHM.sideEngineOn;

        //SESlider.value = SELevel;
        //SESlider.maxValue = 600;
        //SESlider.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 300);

        if (SELevel > 0)
        {
            hEnergy = true;

        }
        else
        {
            hEnergy = false;
            sideSpeed = 0;
        }

        if (SELevel < 0 && SEActive)
        {
            SELevel = 0;
            sideSpeed = 0;
        }

        if (SEActive && SELevel > 0)
        {
            sideSpeed = sideSpeedBasic;
            SELevel = SELevel - SEFac * Time.deltaTime;
        }

        if (SELevel < SELevelMax && !SEActive)
        {
            SELevel = SELevel + ((MEC.sideLevelMax / 20) + SERegV )* Time.deltaTime;
        }

        if (SELevel >= SELevelMax)
        {
            SELevel = SELevelMax;
        }


    }

}
