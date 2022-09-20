using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartGame : MonoBehaviour
{
    [SerializeField] TMP_Text countdownText;
    [SerializeField] Animator animator;
    [SerializeField] GameObject objectStart;
    public void Start(){
        Time.timeScale = 0;
        StartCoroutine(StartGameCoroutine());
    }

    IEnumerator StartGameCoroutine(){
        for(int i = 3; i>0; i--){
            countdownText.text = (i).ToString();
            yield return new WaitForSecondsRealtime(1f);
        }
        countdownText.text = "GO!";
        objectStart.GetComponent<GameOverManager>().StartTimer();
        yield return new WaitForSecondsRealtime(1f);
        Object.Destroy(gameObject);
    }
}
