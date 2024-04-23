using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]  
public class PlayerLocomotion : MonoBehaviour
{
    InputManager _inputManager;
    CameraManager _cameraManager;
    CharacterController _characterController;
    Vector3 _moveDirection;
    Transform _cameraObject;

    [Header("Falling Values")]
    [SerializeField] private float _gravity = 9.8f;
   
    [Header("Speed Values")]  
    [SerializeField] private float _walkingSpeed = 2.0f;
    [SerializeField] private float _runningSpeed = 5.0f;

    [Header("Jump Values")]
    [SerializeField] private float _jumpForce = 5.0f;

    private float _movementSpeed;

    private void Awake()
    {
        _movementSpeed = _walkingSpeed;
        _inputManager = GetComponent<InputManager>();
        _characterController = GetComponent<CharacterController>();
        _cameraManager = FindAnyObjectByType<CameraManager>();
        _cameraObject = Camera.main.transform;
    }


    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
       // HandleJump();   
    }

    private void HandleMovement()
    {
       _movementSpeed = MoveSpeed();
      
        Vector3 direction = _cameraObject.forward;
        direction.y = 0f;
        direction.Normalize();

        _moveDirection = direction * (_inputManager.verticalInput * _movementSpeed);

        // Calcula el movimiento lateral en relación con la dirección de la mirada
        _moveDirection += _cameraObject.right * (_inputManager.horizontalInput * _movementSpeed);

        _moveDirection.y -= _gravity * Time.deltaTime; 

       _characterController.Move(_moveDirection*Time.deltaTime);

       

    }

    private void HandleJump()
    {
       
    }

    private void HandleRotation()
    {
       transform.Rotate(Vector3.up * _cameraManager.playerRotateValue);
     
    }
    

    float MoveSpeed()
    {
        if (_inputManager.runningButton && _inputManager.aimingButton == false)
        {
            return _runningSpeed;
        }
        else
        {
            return _walkingSpeed;
        }

    }
}
