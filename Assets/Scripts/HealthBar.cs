using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    float currentHealth;
    [SerializeField] private float maxHealth;

    private Transform bar;


    void Start()
    {
        bar = transform.Find("Bar");
        currentHealth = maxHealth;
        
    }
    public void addDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }

    void Update()
    {
        Debug.Log(currentHealth);
    }
}
