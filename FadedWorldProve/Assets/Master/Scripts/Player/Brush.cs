using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Brush : MonoBehaviour
{

   public  UnityEvent takeBrush;
   public GameObject indicator;
    bool _indicatorActive;




    private void Update()
    {
        if (_indicatorActive)
        {
            indicator.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
               takeBrush.Invoke();  
            }

        }
        else
        {
            indicator.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _indicatorActive = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _indicatorActive = false;
        }
    }
}
