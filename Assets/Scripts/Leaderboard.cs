using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;

public class Leaderboard : MonoBehaviour{

    [SerializeField] List<TextMeshProUGUI> names;
    [SerializeField] List<TextMeshProUGUI> scores;

    // Public Key to leaderboard data base "https://danqzq.itch.io/leaderboard-creator"
    string publicLeaderboardKey = "403b65e47589a487f65bc7ba3e83ea55f39ad8bab86c424b4c9e9d8d40adbd50";

    void Start(){
        GetLeaderboard();
    }

    public void GetLeaderboard(){

        // Get the data from the database with the public key
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) =>{

            int loopLenght = (msg.Length < names.Count) ? msg.Length : names.Count;
            //assign data to the ones on the Names and Score List
            for (int i = 0; i < loopLenght; ++i){

                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        }));
    }

    public void SetLeaderboardEntry(string username, int score){

        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey,
            username, score, ((msg) => {
                GetLeaderboard();
            }));
    }
}