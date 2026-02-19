using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    [SerializeField] float _shaeDuration=0.5f;
    [SerializeField] float _shakeMagnitude = 0.5f;
    Vector3 _initialPosition;


    void Start()
    {
        _initialPosition = transform.position;
    }

    public void play()
    {
        StartCoroutine(ShakeCamera());
    }
    IEnumerator  ShakeCamera()
    {
       // transform.position = _initialPosition + Random.insideUnitCircle * _shakeMagnitude;

        
      return null;  
    }
}
