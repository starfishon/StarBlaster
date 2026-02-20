using UnityEngine;
using TMPro;
public class PlayerLife : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI _PlayerLife;

    public void UpdateLife(int value,int life)
    {
       life -=value; 
       _PlayerLife.text = life.ToString();
    }
    public void setLife(int value)
    {
        _PlayerLife.text = value.ToString();
    }
}
