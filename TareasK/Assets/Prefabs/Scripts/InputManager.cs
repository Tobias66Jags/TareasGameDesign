using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls _playerControls;
    AnimatorManager _animatorManager;

   

    Vector2 _movementInput;
    Vector2 _cameraInput;

    public float cameraInputX;
    public float cameraInputY;

    public float moveAmount;
    public float sideMove;
    public float verticalInput;
    public float horizontalInput;

    public bool runningButton = false;  
    public bool aimingButton = false;   


    public bool jumpingButton = false;   

    private void Awake()
    {
        _animatorManager = GetComponent<AnimatorManager>();
    }

    private void OnEnable()
    {
        if (_playerControls == null)
        {
            _playerControls = new PlayerControls();
            _playerControls.PlayerMovement.Movement.performed += i => _movementInput = i.ReadValue<Vector2>();
            _playerControls.PlayerMovement.Look.performed += i => _cameraInput = i.ReadValue<Vector2>();

            _playerControls.PlayerMovement.Running.started += i => runningButton = true;

            _playerControls.PlayerMovement.Aiming.performed += i => aimingButton = true;
            _playerControls.PlayerMovement.Aiming.canceled += i => aimingButton = false;

            _playerControls.PlayerMovement.Jump.started += i => jumpingButton = true;   
        }
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
        //HandleJumpingInput
        //HandleActionInput
    }

    private void HandleMovementInput()
    {
      
        verticalInput = _movementInput.y;
        horizontalInput = _movementInput.x;

        cameraInputX = _cameraInput.x;
        cameraInputY = _cameraInput.y;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        sideMove = horizontalInput;


        if (aimingButton)
        {
            runningButton = false;
        }
        if (moveAmount <= 0)
        {
            runningButton = false;
        }
    }

    
}
