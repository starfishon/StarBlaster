using System.Collections;
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

IEnumerator FollowParticle(ParticleSystem ps, Transform target)
{

    while (ps != null)
    {
        ps.transform.position = target.position;
        yield return null; // חשוב! מחכה לפריים הבא
        
    }
    
}
private static Transform _projectilesRoot;

    void Awake()
    {
        // יוצרים פעם אחת Root מסודר לכל היריות
        if (_projectilesRoot == null)
        {
            var go = GameObject.Find("Particals");
            if (go == null) go = new GameObject("Particals");
            _projectilesRoot = go.transform;
        }
    }

void GetHitPartical()
    {
        if (_hitPartical!=null){
       ParticleSystem particalVerb = Instantiate(_hitPartical,transform.position,Quaternion.identity,_projectilesRoot);

         StartCoroutine(FollowParticle(particalVerb, transform));
       Destroy(particalVerb.gameObject,_hitPartical.main.duration+ _hitPartical.main.startLifetime.constantMax);
         }
    }



}
