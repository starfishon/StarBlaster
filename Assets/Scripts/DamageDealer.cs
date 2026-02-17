using UnityEngine;

public class DamageDealer : MonoBehaviour
{
   [SerializeField] int _Damage=10;
   [SerializeField] string _weapon="Generic";

   public int GetDamage()
    {
     return _Damage;   
    }

    public string GetWeapon()
    {
     return _weapon;   
    }



}
