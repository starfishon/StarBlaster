using UnityEngine;

public class DamageDealer : MonoBehaviour
{
   [SerializeField] int _Damage=10;
   [SerializeField] string _weapon="Generic";
   [SerializeField] int  _score=10;


   public int GetDamage()
    {
     return _Damage;   
    }

    public string GetWeapon()
    {
     return _weapon;   
    }

    public void Hit()
    {

        Destroy(gameObject);
        
    }

    public int GetScore()
    {

        return _score;
        
    }



}
