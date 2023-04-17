using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour{
    
    public static GameManager instance;

    public GameObject gameCanvas;
    public GameObject leaderboardCanvas;

    void Awake(){
        
        if(instance == null){
            instance = this; 
        }
    }

    void Start() {

        gameCanvas.SetActive(true);
        leaderboardCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameOver(){
        
        gameCanvas.SetActive(false);
        leaderboardCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame(){

        SceneManager.LoadScene(0);
    }
}