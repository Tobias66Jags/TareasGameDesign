using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    InputManager _inputManager;


    private float _currentLookSpeed;

    [SerializeField] private Transform _cameraHolder;
    [SerializeField] private Transform _cameraObject;

    [Range(0.0f, 1.0f)]
    [SerializeField] private float _cameraLookSpeed = 1f;
    [Range(0.0f, 0.5f)]
    [SerializeField] private float _aimCameraLookSpeed = 0.1f; 
    
    
    
    
 
    [SerializeField] private float _maxCameraSideBump = 20f; 
    [Range(0.0f, 5.0f)]
    [SerializeField] private float _cameraSideSpeed= 0.2f;
   

    public float lookAngle; //Cam look up and down
    public float pivotAngle; //Cam look left and right

    [SerializeField] private float _minPivotAngle = -35;
    [SerializeField] private float _maxPivotAngle = 35;


    public float playerRotateValue;

    float _mouseY = 0;
    float _mouseX = 0;

    private void Awake()
    {
        _currentLookSpeed = _cameraLookSpeed;
        _inputManager = FindObjectOfType<InputManager>();       
    }

    public void HandleAllCameraMovement()
    {
    
        RotateCamera();
        OnSideMovement();
    }

   

    private void RotateCamera()
    {
        _mouseX = _currentLookSpeed * _inputManager.cameraInputX;
        playerRotateValue = _mouseX;
        _mouseY += _currentLookSpeed * _inputManager.cameraInputY;//el += es para darle un limite de rotación
        _mouseY = Mathf.Clamp(_mouseY, _minPivotAngle, _maxPivotAngle);//limite

        _cameraHolder.localEulerAngles = new Vector3(-_mouseY, 0, 0); //negativo porque si es positivo se mueve invertido (logica rara)
      
    }


    private void OnSideMovement()
    {
        float SideMove = Mathf.Clamp(-_inputManager.sideMove * _maxCameraSideBump, -_maxCameraSideBump, _maxCameraSideBump);
        Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, SideMove);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _cameraSideSpeed * Time.deltaTime);

        

      

    }


}
