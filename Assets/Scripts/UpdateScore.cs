using UnityEngine;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   // [SerializeField] TextMeshProUGUI _finalScore;
    void Start()
    {
        int score  = FindFirstObjectByType<ScoreKeeper>().GetScore();
        GetComponent<TextMeshProUGUI>().text = score.ToString("00000000");


    }





    // Update is called once per frame
    void Update()
    {
        int score  = FindFirstObjectByType<ScoreKeeper>().GetScore();
        GetComponent<TextMeshProUGUI>().text = score.ToString("00000000");
        
    }
}
