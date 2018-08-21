using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {

    public GameObject PauseMenu;
    public GameObject StartMenu;
    public GameObject EndMenu;
    public GameObject GameHub;

    public Goal MGoal;

    public string gamestate;

    public Text startHighscore;

    public Text upHighscore;
    public Text doHighscore;

    public string newHighscore;
    public string oldHighscore;

    private float oldscorecount;
    private float newscorecount;



    // Use this for initialization
    void Start () {

        //GameStateStartMenu();
        gamestate = "StartMenu";
        GameStateStartMenu();
        startHighscore.text = "Highscore: 0";

        oldscorecount = 0;
        newscorecount = 0;
}

    // Update is called once per frame
    void Update()
    {
        

        switch (gamestate)
        {
            case "StartMenu":
               
            break;


            case "EndMenu":

            break;


            case "PauseMenu":

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    
                    GameStatePlay();
                    
                }

                break;

            case "Play":

                if (Input.GetKeyDown(KeyCode.Escape))
                {   
                    GameStatePauseMenu();  
                }

                if (MGoal.roundCount >=3)
                {
                    FinishGame();

                }
            break;


        }
    }


    public void GameStateStartMenu() {

        Time.timeScale = 0f;
        StartMenu.SetActive(true);
        PauseMenu.SetActive(false);
        EndMenu.SetActive(false);
        gamestate = "StartMenu";
        GameHub.SetActive(false);
    }

    public void GameStateEndMenu() {

        Time.timeScale = 0f;
        PauseMenu.SetActive(false);
        EndMenu.SetActive(true);
        gamestate = "EndMenu";
        GameHub.SetActive(false);


    }

    public void GameStatePauseMenu() {

        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gamestate = "PauseMenu";
        GameHub.SetActive(false);
    }

    public void GameStateRespawn() { }

    public void GameStatePlay() {

        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gamestate = "Play";
        GameHub.SetActive(true);

    }

    public void QuitGame()
    {
        Application.Quit();




    }


    public void FinishGame()
    {
        oldscorecount = newscorecount;
        newscorecount = MGoal.finalscorecount;

        if(newscorecount > oldscorecount)
        {
            upHighscore.text = "New Highscore! " + MGoal.textHighscore.text;
            doHighscore.text = "";
            newHighscore = MGoal.textHighscore.text;
            startHighscore.text = MGoal.textHighscore.text; 




        }
        else
        {
            upHighscore.text = "Highscore " + newHighscore;
            doHighscore.text = "Your Last Score: " + MGoal.textHighscore.text;
            newscorecount = oldscorecount;

        }


        Time.timeScale = 0f;
        
        GameStateEndMenu();

    }

    public void LoseGame()
    {


       
    }


    public void StartNewGame()
    {
        EndMenu.SetActive(false);
        StartMenu.SetActive(false);
        GameHub.SetActive(true);
        MGoal.roundCount = 0;
        MGoal.scorecounter = 0;
        MGoal.secondsCount = 0;
        MGoal.minuteCount = 0;

        MGoal.textCounter = 3f;
        Time.timeScale = 1f;
        gamestate = "Play";

    }
}
