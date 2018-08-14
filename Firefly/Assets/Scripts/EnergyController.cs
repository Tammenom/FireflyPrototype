using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyController : MonoBehaviour {



    public float boostV;
    public float flankV;
    public float shildV;
    public float eRegV;
    public HoverMotor MHM;
    public ShildController SCtrl;
    public GameObject MRacer;
    public BoostController BCtrl;


    public float shildLevelMax;
    public float shildLevelMaxLimit;
    public float shildLevelMinLimit;

    public float bLevelMax;
    public float bLevelMinLimit;
    public float bLevelMaxLimit;

    public float sideLevelMax;
    public float sideLevelMinLimit;
    public float sideLevelMaxLimit;

    public Slider sideEnergySlider;
    public Slider boostEnergySlider;
    public Slider shildEnergySlider;



    // Use this for initialization
    void Start () {

        MHM = MRacer.GetComponent<HoverMotor>();
        SCtrl = MRacer.GetComponent<ShildController>();
        BCtrl = MRacer.GetComponent<BoostController>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sideEnergySlider.value = sideLevelMax;
        sideEnergySlider.maxValue = 900;
        sideEnergySlider.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 300);

        shildEnergySlider.value = shildLevelMax;
        shildEnergySlider.maxValue = 900;
        shildEnergySlider.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, shildLevelMaxLimit / 3);

        boostEnergySlider.value = bLevelMax;
        boostEnergySlider.maxValue = 900;
        boostEnergySlider.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, bLevelMaxLimit / 3);




        if (Input.GetKey("c") && shildLevelMax < shildLevelMaxLimit && bLevelMax >= bLevelMinLimit && sideLevelMax >= sideLevelMinLimit)
        {
            shildLevelMax = shildLevelMax + Time.deltaTime * 200;

            
                bLevelMax = bLevelMax - Time.deltaTime * 100;
           

                sideLevelMax = sideLevelMax - Time.deltaTime * 100;
           

        }

        if (Input.GetKey("x") && bLevelMax < bLevelMaxLimit && shildLevelMax >= shildLevelMinLimit && sideLevelMax >= sideLevelMinLimit)
        {
            bLevelMax = bLevelMax + Time.deltaTime * 200;

                shildLevelMax = shildLevelMax - Time.deltaTime * 100;

                sideLevelMax = sideLevelMax - Time.deltaTime * 100;

        }

        if (Input.GetKey("y") && sideLevelMax < sideLevelMaxLimit && shildLevelMax >= shildLevelMinLimit && bLevelMax >= bLevelMinLimit)
        {
            sideLevelMax = sideLevelMax + Time.deltaTime * 200;

                shildLevelMax = shildLevelMax - Time.deltaTime * 100;

                bLevelMax = bLevelMax - Time.deltaTime * 100;

        }








    }
}
