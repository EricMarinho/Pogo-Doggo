using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI comboText;
    public int Score { get; private set; } = 0;
    public int Modifier { get; private set ; } = 0;
    public void AddScore(int amount) {
        Score += amount;
        PlayerController.Instance.spawnPrefabPoints.spawnPrefab(amount);
        scoreText.text = "Score: " + Score.ToString();
    }

    public void IncreaseModifier(){
        Modifier++;
        comboText.text = "Combo: x" + Modifier.ToString();
    }

    public void ResetModifier(){
        Modifier = 0;
        comboText.text = "Combo: x" + Modifier.ToString();
    }

}
