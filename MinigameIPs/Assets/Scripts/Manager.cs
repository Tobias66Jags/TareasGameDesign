using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
   public TextMeshProUGUI counter;
   public TextMeshProUGUI globalCounter;

    public float globalTimer;
    float timer;

    private void Update()
    {
        timer = Player.newC;
        counter.text = timer.ToString()+" s";
    }

}
