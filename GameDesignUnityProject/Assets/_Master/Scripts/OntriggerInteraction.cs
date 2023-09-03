using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OntriggerInteraction : MonoBehaviour
{
    public UnityEvent onTriggerEvent;
    public UnityEvent stayTriggerEvent;
    public UnityEvent outTriggerEvent;
    public UnityEvent interactionEvent;




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onTriggerEvent.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            outTriggerEvent.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           stayTriggerEvent.Invoke();
        }
    }

    public void interaction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interactionEvent.Invoke();
        }
    }
}
