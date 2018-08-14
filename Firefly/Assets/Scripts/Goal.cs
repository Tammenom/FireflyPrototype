﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Goal : MonoBehaviour {


    public int roundCount;
    public bool enterGoal1;
    public bool enterGoal2;
    public bool wrongDirection;
    public Text textRound;
    public Text textHighscore;
    private float textCounter;
    private float highscoreCounter;
    private float actualHighscore;

    // Use this for initialization
    void Start () {
        roundCount = 0;
       enterGoal1 = false;
        enterGoal2 = false;
        wrongDirection = false;
        textCounter = 3;
        

    }
	
	// Update is called once per frame
	void Update () {

        highscoreCounter += Time.deltaTime;



        switch (roundCount)
        {
            case 0:

                if (textCounter > 0)
                {
                    textRound.text = "Round 1";
                    textCounter -= Time.deltaTime;
                }
                else
                {
                    textCounter = 0;
                    textRound.text = "";
                }
                break;


            case 1:

                
                if (textCounter < 4)
                {
                    textRound.text = "Round 2";
                    textHighscore.text = "Time " + actualHighscore;
                    textCounter += Time.deltaTime;
                }
                else
                {
                    textCounter = 4;
                    textRound.text = "";
                    textHighscore.text = "";
                }

                break;


            case 2:

                
                if (textCounter > 0)
                {
                    textRound.text = "Final Lap";
                    textHighscore.text = "Time " + actualHighscore;
                    textCounter -= Time.deltaTime;
                }
                else
                {
                    textCounter = 0;
                    textRound.text = "";
                    textHighscore.text = "";
                }
                break;

            case 3:

                
                if (textCounter < 5)
                {
                    textRound.text = "Final";
                    textHighscore.text = "Time " + actualHighscore;
                    
                    textCounter -= Time.deltaTime;
                }
                else
                {
                    
                    textRound.text = "";
                }
                break;

            default:


                textRound.text = "Game End";

                break;



        }

    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Goal1")
        {
            if (!enterGoal2)
            {
                enterGoal1 = true;
            }

            if (enterGoal2 && wrongDirection)
            {
                enterGoal1 = true;
            }
        }

        if (col.gameObject.name == "Goal2")
        {
            if (enterGoal1 && !wrongDirection)
            {
                enterGoal2 = true;
                
            }

            if (!enterGoal1)
            {
                wrongDirection = true;
            }
        }


    }

    void OnTriggerExit(Collider collision)
    {

        if (collision.gameObject.name == "Goal1")
        {
            if (!wrongDirection && enterGoal1 && enterGoal2)
            {
                actualHighscore = highscoreCounter;
                roundCount++;
               


            }

            enterGoal1 = false;
        }
        if (collision.gameObject.name == "Goal2")
        {
            if (wrongDirection && !enterGoal1)
            {
                wrongDirection = false;
            }

            enterGoal2 = false;
        }
    }

        
    

}
