using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI scoreText;
    int _score=0;

    public int GetScore()
    {
        return _score;
    }

    public void UpdateScore(int value)
    {
       _score +=value; 
       scoreText.text = _score.ToString();
    }

    public void RestScore()
    {
        _score = 0;
    }


    void Start()
    {
        RestScore();
        
    }


}
