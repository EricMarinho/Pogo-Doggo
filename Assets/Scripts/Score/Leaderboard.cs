using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class Leaderboard : MonoBehaviour
{

    
    public static Leaderboard Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }

    [SerializeField] TextMeshProUGUI playerName;
    [SerializeField] TextMeshProUGUI playerScore;
    private int leaderboardID = 7095;

    public IEnumerator SubmitScoreRoutine(int scoreToUpload){
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerID");
        string playerName = PlayerPrefs.GetString("PlayerName");
        LootLockerSDKManager.SetPlayerName(playerName, (response) => {
            if(response.success){
                Debug.Log("Player name was set");
            }else{
                Debug.Log("Could not set player name");
            }
        });
        LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, leaderboardID, (response) =>{
            if(response.success){
                Debug.Log("Score was submitted");
            }else{
                Debug.Log("Could not submit score");
            }
            done = true;
        });

        yield return new WaitWhile(() => !done);
    }

    public IEnumerator FetchTopHighScoresRoutine(){
        bool done = false;
        LootLockerSDKManager.GetScoreList(leaderboardID, 10, 0, (response) =>{

            if(response.success){
                string tempPlayerNames = "Names:\n";
                string tempPlayerScores = "Scores:\n";

                LootLockerLeaderboardMember[] members = response.items;

                foreach(LootLockerLeaderboardMember member in members){
                    tempPlayerNames += member.rank + ". ";
                    if(member.player.name != ""){
                        tempPlayerNames += member.player.name;
                    }
                    else{
                        tempPlayerNames += member.player.id;
                    }
                    tempPlayerScores += member.score + "\n";
                }
                Debug.Log("Leaderboard was retrieved");
                done = true;
                playerName.text = tempPlayerNames;
                playerScore.text = tempPlayerScores;
            }else{
                Debug.Log("Failed" + response.Error);
                done = true;
            }

        });

        yield return new WaitWhile(() => !done);
    }

}
