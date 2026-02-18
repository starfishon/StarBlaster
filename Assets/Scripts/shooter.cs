using System.Collections;
using UnityEngine;

public class shooter : MonoBehaviour
{
    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] float _projeSpeed;
    [SerializeField] float _projectLifeTime;
    [SerializeField] float _fireRate;

    public bool IsFring;
    Coroutine fireCorotine;

    void Update()
    {
        fire();
    }

    void fire()
    {
        if (IsFring && fireCorotine==null)
        {
            fireCorotine = StartCoroutine(FireContinuesly());
        }
        else if (!IsFring && fireCorotine!=null)
        {
            StopCoroutine(fireCorotine);
            fireCorotine = null;

        }
        
    }

    IEnumerator FireContinuesly()
    {
        while (true)
        {
          GameObject projectile =       Instantiate(
                _projectilePrefab,
                transform.position,
                Quaternion.identity);
                Destroy(projectile,_projectLifeTime);

            Rigidbody2D projectRB = projectile.GetComponent<Rigidbody2D>();
            projectRB.linearVelocityY = _projeSpeed;
            yield return new WaitForSeconds(_fireRate);
        }
    }


}
