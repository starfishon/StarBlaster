using System.Collections;
using Unity.VisualScripting;
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
    IEnumerator ShakeCamera()
    {

      float _deltaTime =0;
      while  (_deltaTime<=_shaeDuration){
      _deltaTime += Time.deltaTime;
      transform.position = _initialPosition + (Vector3)Random.insideUnitCircle * _shakeMagnitude;
      yield return new WaitForEndOfFrame();
      }
      transform.position = _initialPosition;
      
    }
}
