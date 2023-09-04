using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public bool canGetDamage=true;

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
        if (currentHealth<=0)
        {
            GameManager.Instance.LoadScene("SampleScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Damage") && canGetDamage)
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
