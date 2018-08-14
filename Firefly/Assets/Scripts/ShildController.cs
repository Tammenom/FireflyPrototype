using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShildController : MonoBehaviour {

    public GameObject rShild;
    public GameObject lShild;
    public float timeBooster = 0.5f;
    public float shildLevel;
    public float shildLevelMax;
    public float shildRegV;
    private float energyLevel;
    public GameObject MRacer;
    public HoverMotor MHM;
    public EnergyController MEC;
    private bool hasEnergy;
    public bool impact;
    //public Slider shildBar;
    //public RectTransform shildHub;
    private float timeBoosterValue;

// Use this for initialization
void Start () {
        MEC = MRacer.GetComponent<EnergyController>();
        MHM = MRacer.GetComponent<HoverMotor>();
        shildLevelMax = 600;
        shildLevel = shildLevelMax;
        timeBoosterValue = Time.deltaTime;
        impact = false;
}

    // Update is called once per frame
    void FixedUpdate()
    {
        

        if (shildLevel < shildLevelMax)
        {
            shildLevel = shildLevel + (shildRegV + (MEC.shildLevelMax/55))*Time.deltaTime;
        }

        if (shildLevel >= shildLevelMax)
        {
            shildLevel = shildLevelMax;
        }

        if (timeBooster >= 0)
        {
            timeBooster = timeBooster - Time.deltaTime;
        }



        if (timeBooster <= 0)
        {
            rShild.SetActive(false);
            lShild.SetActive(false);
        }



        //shildBar.value = shildLevel;
        //shildBar.maxValue = 600;
        //shildBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 300);
        //shildBar.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, shildLevelMax);
    }
        void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Terrain31")
        {
            timeBooster = 1.0f;

            rShild.SetActive(true);
            lShild.SetActive(true);

            if(MHM.speed >= 130&& timeBooster == 1.0f)
            {
                shildLevel = shildLevel - (MHM.speed/2);
                MHM.speed = 100;

                if (shildLevel <= 0)
                {
                    SceneManager.LoadScene("Menu");
                }

                
            }

            impact = true;
        }
        else
        {
            impact = false;
        }
        
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Terrain31")
        {
            
        }
    }

   
}
