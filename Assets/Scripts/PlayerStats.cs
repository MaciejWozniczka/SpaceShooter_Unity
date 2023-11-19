using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    private int healingTimeInterval = 1;
    private float timer = 0;
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth < maxHealth)
        {
            if (Time.time > timer)
            {
                currentHealth++;
                timer += healingTimeInterval;
            }
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
