using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

    void Update(){
        if(Input.GetKeyDown(KeyCode.P)){
            StartCoroutine(GameOver());
        }
    }

    public IEnumerator GameOver() {
        yield return Leaderboard.Instance.SubmitScoreRoutine(PlayerController.Instance.scoreHandler.Score);
        yield return Leaderboard.Instance.FetchTopHighScoresRoutine();
    }

}
