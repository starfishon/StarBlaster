using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
public class ShipStatus : MonoBehaviour
{

[SerializeField] int _Health = 50;
[SerializeField] bool _IsPlayer=false;
[SerializeField] ParticleSystem _hitPartical;
[SerializeField] bool _applyCameraShake;

ScoreKeeper _score;

AudioManager _audioManager;

DamageDealer damageDealer;
PlayerLife _playerlife;
CameraShake _camera;
MenuButtons  _menuButtons;
    void Start()
    {
        _playerlife = FindFirstObjectByType<PlayerLife>();
        if (_IsPlayer)  _playerlife.setLife(_Health);
        _score = FindFirstObjectByType<ScoreKeeper>();

        _camera = Camera.main.GetComponent<CameraShake>();
        _audioManager = FindFirstObjectByType<AudioManager>();
        _menuButtons = FindFirstObjectByType<MenuButtons>();

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
       // if (gameObject.layer == collision.gameObject.layer) return ;
        damageDealer = collision.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            DoDamage(damageDealer.GetDamage());
            
            GetHitPartical();
            
            damageDealer.Hit();
            if (_applyCameraShake)
            {
                _camera.play();
            }
        }

    }
void  DoDamage(int damage){
    if (_IsPlayer) _playerlife.UpdateLife(damage,_Health);
    _Health-= damage;
    
    ChecKLife();
    
}



void ChecKLife()
    {
       if (_Health<=0) {
        _audioManager.ExplodeSFX();

        if (_IsPlayer)
            {
                
                _menuButtons.LoadGameOver();
            }

        else 
        {
            _score.UpdateScore(GetComponent<DamageDealer>().GetScore());
        }

       
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
        _audioManager.PlayHiySFX();
        if (_hitPartical!=null){
       ParticleSystem particalVerb = Instantiate(_hitPartical,transform.position,Quaternion.identity,_projectilesRoot);

         StartCoroutine(FollowParticle(particalVerb, transform));
       Destroy(particalVerb.gameObject,_hitPartical.main.duration+ _hitPartical.main.startLifetime.constantMax);
         }
    }



}
