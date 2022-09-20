using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameInput : MonoBehaviour
{

    private string playerName;
    private TMP_InputField inputField;
    private MenuManager menuManager;

    private void Start()
    {
        inputField = FindObjectOfType<TMP_InputField>().GetComponent<TMP_InputField>();
        menuManager = GetComponent<MenuManager>();
    }

    public void SetName(){
        playerName = inputField.textComponent.text;
        PlayerPrefs.SetString("PlayerName", playerName);
        menuManager.PlayStage1();  
    }

}
