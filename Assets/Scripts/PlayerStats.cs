using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth++;
        }
    }

    public void PlayerTakeDamage(float dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
