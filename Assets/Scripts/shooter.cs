using System.Collections;
using UnityEngine;

public class shooter : MonoBehaviour
{
    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] float _projeSpeed;
    [SerializeField] float _projectLifeTime;
    [SerializeField] float _fireRate;
    [SerializeField] bool useAI;
   // [SerializeField] private Transform _projectileParent;

    [HideInInspector] public bool _IsFiring;
    Coroutine fireCorotine;


    private static Transform _projectilesRoot;

    void Awake()
    {
        // יוצרים פעם אחת Root מסודר לכל היריות
        if (_projectilesRoot == null)
        {
            var go = GameObject.Find("Projectiles");
            if (go == null) go = new GameObject("Projectiles");
            _projectilesRoot = go.transform;
        }
    }

    void Update()
    {
        if (useAI)
        {
            _IsFiring = true;
        }
        fire();
    }

    void Start()
    {
    }

    void fire()
    {
        if (_IsFiring && fireCorotine==null)
        {
            fireCorotine = StartCoroutine(FireContinuesly());
        }
        else if (!_IsFiring && fireCorotine!=null)
        {
            StopCoroutine(fireCorotine);
            fireCorotine = null;

        }
        
    }
    [Header("AI Section")]
    [SerializeField] float _TimeShoot= 2f;
    [SerializeField] float _ShootVariance=1f;
    [SerializeField] float _miniShootTime=0.2f;


    public float GetRandomEnemySpawnTime()
    {
        float shootTime = Random.Range(_TimeShoot - _ShootVariance,
        _TimeShoot + _ShootVariance);
      //  Debug.Log(shootTime);
        shootTime = Mathf.Clamp(shootTime+_ShootVariance,_miniShootTime,float.MaxValue);
        return shootTime;
    }

    IEnumerator FireContinuesly()
    {
        while (true)
        {
          GameObject projectile =       Instantiate(
                _projectilePrefab,
                transform.position,
                Quaternion.identity,_projectilesRoot);
                Destroy(projectile,_projectLifeTime);

            projectile.transform.rotation = transform.rotation;
            float currentFireRate;
            if (useAI) 
            {
                currentFireRate = GetRandomEnemySpawnTime();
                }
            else
            {
                currentFireRate = _fireRate;
            }
            Rigidbody2D projectRB = projectile.GetComponent<Rigidbody2D>();
            //projectRB.linearVelocityY = _projeSpeed;
            projectRB.linearVelocity = transform.up * _projeSpeed;
            yield return new WaitForSeconds(currentFireRate);
        }
    }


}
