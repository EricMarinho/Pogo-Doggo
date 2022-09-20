using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance { get; private set; }
    [SerializeField] GameObject leaderBoard;

    private float timeLeft = 120f;
    public TMP_Text timeText;
    private bool isTimerOn = false;
    public bool isPlayble = true;
    [SerializeField] GameObject timeConteiner;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject scoreContainer;
    [SerializeField] GameObject pauseButton;
    private void Awake() {
        Instance = this;
    }

    void Update(){

        if(isTimerOn){
            timeLeft -= Time.deltaTime;
            UpdateTimer(timeLeft);
            if(timeLeft < 0){
                timeLeft = 0;
                isTimerOn = false;
                EndGame();
            }
        }
    }

    void UpdateTimer(float currentTime){
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timeText.text = "Time Left: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public IEnumerator GameOverRoutine() {
        yield return Leaderboard.Instance.SubmitScoreRoutine(PlayerController.Instance.scoreHandler.Score);
        yield return Leaderboard.Instance.FetchTopHighScoresRoutine();
    }

    public void StartTimer(){
        isTimerOn = true;
        Time.timeScale = 1;
    }

    public void PauseTimer(){
        if(isTimerOn){
            isTimerOn = false;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else{
            isTimerOn = true;
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }   
    }

    private void EndGame(){
        timeConteiner.SetActive(false);
        leaderBoard.SetActive(true);
        scoreContainer.SetActive(false);
        pauseButton.SetActive(false);
        isPlayble = false;
        StartCoroutine(GameOverRoutine());
    }

}
