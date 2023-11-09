using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float maxTime = 5;
    public float currentTime;

    public TextMeshProUGUI timerView;


    private void Start()
    {
        currentTime = maxTime;
        StartCoroutine(SetTimer());
    }

    [ContextMenu("Timer")]
    public void InitializeTimer()
    {
        currentTime = maxTime;
        StartCoroutine(SetTimer());
    }

    private void Update()
    {
        Debug.Log(currentTime);
        timerView.text = currentTime.ToString();
    }
    public IEnumerator SetTimer ()
    {
        while (currentTime>0)
        {
            currentTime--;
            yield return new WaitForSecondsRealtime(1);
        }
        
    } 
}
