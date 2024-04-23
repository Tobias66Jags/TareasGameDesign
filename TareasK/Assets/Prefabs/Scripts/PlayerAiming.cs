using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Animations.Rigging;

public class PlayerAiming : MonoBehaviour
{
    InputManager _inputManager;

    [SerializeField] int _gunIndex = 0;

   /* [SerializeField] private Rig _longAimingRig;
    [SerializeField] private Rig _shortAimingRig;*/

    [SerializeField] private float _aimSpeed = 0.3f;

    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
    }

    public void HandleAllAimings()
    {
       /* switch (_gunIndex)
        {
            case 0:
                HandleToPrincipalAiming(_longAimingRig);
                break;
            case 1:
                HandleToPrincipalAiming(_shortAimingRig);
                break;
        }*/
       
    }


    /*private void HandleToPrincipalAiming(Rig currentRig)
    {
        if (_inputManager.aimingButton)
        {
            currentRig.weight += Time.deltaTime / _aimSpeed;
        }
        else
        {
            currentRig.weight -= Time.deltaTime / _aimSpeed;

        }
    }*/
}
