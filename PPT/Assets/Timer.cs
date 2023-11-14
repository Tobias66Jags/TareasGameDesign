using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public Win win;

    public float maxTime = 5;
    public float currentTime;

    public TextMeshProUGUI timerView;

    public string url1, url2;
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

        if (currentTime <= 1)
        {
            Debug.Log("UWU");
            win.winner();
        }
      
        Debug.Log(currentTime);
        timerView.text = currentTime.ToString();
    }
    public IEnumerator SetTimer ()
    {
        while (currentTime>0)
        {
            win.setChooseP1(url1);
            win.setChooseP2(url2);
            currentTime--;
            yield return new WaitForSecondsRealtime(1);
        }
        
    } 
}
