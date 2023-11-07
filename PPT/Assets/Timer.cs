using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float maxTime = 5;
    public float currentTime;

    private void Start()
    {
        currentTime = maxTime;
        StartCoroutine(SetTimer(currentTime));
    }

    private void Update()
    {
        Debug.Log(currentTime);
    }
    public IEnumerator SetTimer (float time)
    {
        while (time>0)
        {
            time--;
            yield return new WaitForSecondsRealtime(1);
        }
        
    } 
}
