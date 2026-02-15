using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "New_WaveConfig")]
public class WaveSO : ScriptableObject
{
     [SerializeField] Transform _pathPrefab;
    [SerializeField] GameObject[] _enemyPrefabs;
    [SerializeField] float _enemyMove_speed = 5;

    [SerializeField] float _timeSpawn= 1;
    [SerializeField] float _enemySpawnVariance=0f;
    [SerializeField] float _miniSpawnTime=0.2f;

    public float GetRandomEnemySpawnTime()
    {
        float spawnTime = Random.Range(_timeSpawn - _enemySpawnVariance,
        _timeSpawn + _enemySpawnVariance);
        
        spawnTime = Mathf.Clamp(spawnTime,_miniSpawnTime,float.MaxValue);
        return spawnTime;
    }

    public int GetEnemiesCount()
    {
        return _enemyPrefabs.Length;
    }

    public GameObject GetEnemeyPrefab(int index)
    {
        return _enemyPrefabs[index];
    }
    public Transform GetStartingWayPoint()
    {
        return _pathPrefab.GetChild(0);
    }

    public float GetEnemyMoveSpeed()
    {
        return _enemyMove_speed;
    }

    public Transform[] Getwaypoints()
    {
        Transform[] _waypoints = new Transform[_pathPrefab.childCount];
        for (int i=0; i< _pathPrefab.childCount; i++)
        {
           _waypoints[i] = _pathPrefab.GetChild(i);
        }
        
        return _waypoints;
    }
    
}
