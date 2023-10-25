using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class FSM : MonoBehaviour
{
    protected virtual void initialize() { }
    protected virtual void FSMUpdate() { }
    protected virtual void FMSFixedUpdate() { }



    // Start is called before the first frame update
    private void Start()
    {
        initialize();
    }


    private void Update()
    {
        FSMUpdate();
    }


    private void FixedUpdate()
    {
        FMSFixedUpdate();
    }


}
