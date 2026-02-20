using UnityEngine;
using TMPro;


public class ScoreKeeper : MonoBehaviour
{
    
    public static ScoreKeeper instance;
    int _score=0;

    public int GetScore()
    {
        return _score;
    }

    public void UpdateScore(int value)
    {
       _score +=value; 

    }

    public void RestScore()
    {
        _score = 0;
    }


    void Awake()
    {
      if (instance!=null)
        {
                Debug.Log("you destroyed me!!!");
                gameObject.SetActive(false);
                Destroy(gameObject);
        }
        else
        {
            Debug.Log("you DONT destroyed me!!!");
          instance = this;
          DontDestroyOnLoad(gameObject);
        }
        Debug.Log(GetScore() + " " + FindObjectsByType<ScoreKeeper>(FindObjectsSortMode.None).Length);
      
    }


}
