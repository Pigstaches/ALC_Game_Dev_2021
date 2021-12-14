using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scoreToWin;
    public int curScore;
    public bool gamePaused;
    public static GameManager instance;
    //instance of game manager

    void Awake()
    {
        //set the instance of this script
        instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Cancel"))
        {
            TogglePauseGame();
        }
    }
    public void TogglePauseGame()
    {
        // freeze game
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;

        //Toggle pause menu
        GameUI.instance.TogglePauseMenu(gamePaused);

        //Toggle mouse cursor
        Cursor.lockState = gamePaused == true ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void AddScore(int score)
    {
        curScore += score;
        
        //Update score text vortex
        GameUI.instance.UpdateScoreText(curScore);

        //have we reached the score to win
        if(curScore >= scoreToWin)
            WinGame();
    }

    public void WinGame()
    {
        //set end game screen
        GameUI.instance.SetEndGameScreen(true,curScore);
    }

    public void LoseGame()
    {
        //Set the end game screen
        GameUI.instance.GetEndGameScreen(false, curScore);
        Time.timeScale = 0.0f;
        gamePaused = true; 
    }

}
