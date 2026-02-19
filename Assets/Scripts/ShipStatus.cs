using UnityEngine;

public class ShipStatus : MonoBehaviour
{

[SerializeField] int _Health = 50;
[SerializeField] ParticleSystem _hitPartical;
DamageDealer damageDealer;

void OnTriggerEnter2D(Collider2D collision)
    {
       // if (gameObject.layer == collision.gameObject.layer) return ;
        damageDealer = collision.GetComponent<DamageDealer>();
        Debug.Log("we got hit mayday");

        
        if (damageDealer != null)
        {
            DoDamage(damageDealer.GetDamage());
            GetHitPartical();
            damageDealer.Hit();
        }

    }
void  DoDamage(int damage){
    _Health-= damage;
    ChecKLife();
    
}

void ChecKLife()
    {
       if (_Health<=0) {
        
        Destroy(gameObject); 
       }

    }

void GetHitPartical()
    {
        if (_hitPartical!=null){
       ParticleSystem particalVerb = Instantiate(_hitPartical,transform.position,Quaternion.identity,transform);
       Destroy(particalVerb,_hitPartical.main.duration+ _hitPartical.main.startLifetime.constantMax);

   

        }
    }



}
