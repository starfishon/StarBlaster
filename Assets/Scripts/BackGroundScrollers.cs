using UnityEngine;

public class BackGroundScrollers : MonoBehaviour
{
 [SerializeField] Vector2 _movespeed;
 Vector2  offset;
 Material material;


    void Update()
    {
        ChangeBackGorund();
    }

    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;

        offset = material.mainTextureOffset;



    }

    void ChangeBackGorund()
    {
        offset = material.mainTextureOffset;
        material.mainTextureOffset = material.mainTextureOffset + _movespeed * Time.deltaTime;
    }




}
