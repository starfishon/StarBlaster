using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerLife : MonoBehaviour
{
    [SerializeField] public Slider _PlayerLife;

    public void UpdateLife(int value,int life)
    {
       life -=value; 
       _PlayerLife.value = life;
    }
    public void setLife(int value)
    {
        _PlayerLife.value = value;
    }
}
