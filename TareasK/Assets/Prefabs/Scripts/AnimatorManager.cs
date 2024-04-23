using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    Animator _animator;
    int speed;
    int _horizontal;
    int _vertical;

    bool _running;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
      
        
    }

    public void UpdateAnimatorValues(float horizontalMovement, float verticalMovement, bool isRunning)
    {
      
       
    }
}
