using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    public int Score { get; private set; } = 0;
    public int Modifier { get; set; } = 0;
    public void AddScore(int amount) {
        Score += amount;
        scoreText.text = "Score: " + Score.ToString();
    }

}
