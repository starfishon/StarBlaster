using UnityEngine;

public class ShipStatus : MonoBehaviour
{

[SerializeField] int _Health = 50;
DamageDealer damageDealer;

void OnTriggerEnter2D(Collider2D collision)
    {
        damageDealer = collision.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            DoDamage(damageDealer.GetDamage());
        }

        ChecKLife();


    }
void  DoDamage(int damage){
    _Health-= damage;
}

void ChecKLife()
    {
        if (_Health<=0) Destroy(gameObject);

    }





}
