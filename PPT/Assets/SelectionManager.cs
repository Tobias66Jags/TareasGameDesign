using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private float RoundChoose=0;


    private void Update()
    {
        Debug.Log(RoundChoose);
    }


    public void Choose(float thisNumber)
    {
        RoundChoose = thisNumber;
    }
}
