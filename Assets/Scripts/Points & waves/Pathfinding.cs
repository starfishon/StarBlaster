using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveSO _waveConfig;
    Transform[] _way_wayPoints;
    int _wayPointIndex=0;

    void Start()
    {
        enemySpawner = FindAnyObjectByType<EnemySpawner>();
        _waveConfig = enemySpawner.GetWave();
       _way_wayPoints = _waveConfig.Getwaypoints();
       transform.position = _waveConfig.GetStartingWayPoint().position;
    }

    void Update()
    {
        FollowPath();
    }
    void FollowPath()
    {
        if (_wayPointIndex < _way_wayPoints.Length)
        {
            Vector3 targetPosition = _way_wayPoints[_wayPointIndex].position;
            float moveDelta = _waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,targetPosition,moveDelta);
            if (transform.position == targetPosition)
            {
                _wayPointIndex++;
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }


}
