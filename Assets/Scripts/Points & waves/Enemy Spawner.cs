using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveSO[] _waveConfigs;
    [SerializeField] float _timeBetweenWaves=1f;
    [SerializeField] bool _isloop=false;
    WaveSO _currentWave;
    float _currentDelta;

    void Start()
    {
        StartCoroutine(SpawnEnemies());

    }

    

    IEnumerator SpawnEnemies()
    {
        do
        {
            
       
        foreach (WaveSO wave in _waveConfigs)
        {
            _currentWave = wave;

            for ( int i =0 ; i< _currentWave.GetEnemiesCount(); i++)
            {

            Instantiate(
                _currentWave.GetEnemeyPrefab(i),
                _currentWave.GetStartingWayPoint().position,
                Quaternion.identity,
                transform);
            yield return new WaitForSeconds(_currentWave.GetRandomEnemySpawnTime());
            }

            yield return new WaitForSeconds(_timeBetweenWaves);
        }
        }
        while (_isloop==true);
    }

    public WaveSO GetWave()
    {
        return _currentWave;
    }
}
