using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private Image healthFill;
    private int healingTimeInterval = 1;
    private float timer = 0;
    void Start()
    {
        currentHealth = maxHealth;
        healthFill.fillAmount = 1;
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
        healthFill.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
