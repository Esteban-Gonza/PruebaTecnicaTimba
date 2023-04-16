using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ScoreManager : MonoBehaviour{

    [SerializeField] TextMeshProUGUI inputScore;
    [SerializeField] TMP_InputField inputName;

    public UnityEvent<string, int> submitScoreEvent;

    public void SubmitScore(){
        submitScoreEvent.Invoke(inputName.text, int.Parse(inputScore.text));
    }
}