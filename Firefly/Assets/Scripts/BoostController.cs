using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostController : MonoBehaviour {

    public float eLevel;
    public float eLevelMax;
    public float eLevelMin;
    public float eRegV;
    public float eFac;
    public bool hEnergy;
    public bool boostActive;
    public HoverMotor MHM;
    public EnergyController ECtrl;
    public GameObject MRacer;
    //public Slider eBar;
    //public RectTransform eHub;


    // Use this for initialization
    void Start()
    {

        hEnergy = true;
        MHM = MRacer.GetComponent<HoverMotor>();
        ECtrl = MRacer.GetComponent<EnergyController>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        eLevelMax = 600;
        boostActive = MHM.boost;

       // eBar.value = eLevel;
        //eBar.maxValue = 600;
        //eBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 300);

        if (eLevel > 0)
        {
            hEnergy = true;

        }
        else
        {
            hEnergy = false;
        }

        if(eLevel <= 0 && boostActive)
        {
            eLevel = 0;
        }

        if (boostActive)
        {
            eLevel = eLevel - eFac * Time.deltaTime;
        }

        if (eLevel < eLevelMax && !boostActive)
        {
            eLevel = eLevel+((ECtrl.bLevelMax / 30)+ eRegV) * Time.deltaTime;
        }

        if (eLevel >= eLevelMax)
        {
            eLevel = eLevelMax;
        }


    }
}