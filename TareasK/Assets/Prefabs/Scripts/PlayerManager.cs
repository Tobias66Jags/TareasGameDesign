using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager _inputManager;
    CameraManager _cameraManager;
    PlayerLocomotion _playerLocomotion;
    PlayerAiming _playerAiming;
    AnimatorManager _animatorManager;
    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _cameraManager = FindObjectOfType<CameraManager>();
        _playerLocomotion = GetComponent<PlayerLocomotion>();
        _playerAiming = GetComponent<PlayerAiming>();
        _animatorManager = GetComponent<AnimatorManager>();
    }

    private void Update()
    {      
        _playerLocomotion.HandleAllMovement();
        _inputManager.HandleAllInputs();
        _cameraManager.HandleAllCameraMovement();
        //_animatorManager.UpdateAnimatorValues(_inputManager.horizontalInput, _inputManager.verticalInput, _inputManager.runningButton);
    }

    private void FixedUpdate()
    {
     
    }

    private void LateUpdate()
    {
        
    }
}
