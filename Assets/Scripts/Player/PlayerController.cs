using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputAction _moveAction;
    Vector3 _MoveVector;
    [SerializeField] float _ShipSpeed=20f;
    Vector2 _PlayerMovementVector;
    Vector2 _minBounds;
    Vector2 _maxBounds;
    shooter _PlayerShooter;
    InputAction _fireAction;


    void Start()
    {
        _PlayerShooter = GetComponent<shooter>();
        _fireAction = InputSystem.actions.FindAction("Fire");

       _moveAction = InputSystem.actions.FindAction("Move");
       InitBounds();
    }

    void FireShooter()
    {
        _PlayerShooter.IsFring = _fireAction.IsPressed();

    }
    void Update()
    {
        MovePlayer();
        FireShooter();
    }
    void InitBounds()
    {
        Camera _mainCamera = Camera.main;
        _minBounds = _mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        _maxBounds = _mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }



    void OnMove(InputValue value)
    {
    //   _PlayerMovementVector = value.Get<Vector2>(); 
   
    }
   
   void MovePlayer()
    {
      _MoveVector = _moveAction.ReadValue<Vector2>();
     //  transform.position+= new Vector3(_MoveVector.x,_MoveVector.y,0f);
     float _deltaTime = Time.deltaTime;
     Vector3 _newPose = transform.position + _MoveVector * _deltaTime * _ShipSpeed;

    float shipSize = 2;
    _newPose.x = Math.Clamp(_newPose.x,_minBounds.x+shipSize,_maxBounds.x-shipSize);
    _newPose.y = Math.Clamp(_newPose.y,_minBounds.y+shipSize,_maxBounds.y-shipSize);




     transform.position=  _newPose;


    }
       
    
}
