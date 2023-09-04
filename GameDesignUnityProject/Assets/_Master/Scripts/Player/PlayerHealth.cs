using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public UnityEvent OnDeath;

    public Animator feedAnim; 

    public Image LifeBar;
   
    public float currentHealth = 100;
    public float MaxHealth = 100;

  
    private void Update()
    {
        LifeBar.fillAmount = currentHealth / MaxHealth;

        if (currentHealth<=MaxHealth)
        {
            OnDeath.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Damage"))
        {
            GetDamage(5);
        } 
        if (other.CompareTag("DeadZone"))
        {
            GetDamage(10);
        }
    }


    [ContextMenu("Knockback")]
    public void GetDamage(float damage)
    {
        currentHealth -= damage;
        feedAnim.Play("GetDamage");
    }


   
}
