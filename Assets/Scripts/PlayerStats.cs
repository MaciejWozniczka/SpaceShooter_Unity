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
    [SerializeField] private GameObject playerExplosion;
    [SerializeField] private Animator anim;
    private bool canPlayAnim;
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
                healthFill.fillAmount = currentHealth / maxHealth;
                timer += healingTimeInterval;
            }
        }
    }

    public void PlayerTakeDamage(float dmg)
    {
        currentHealth -= dmg;
        healthFill.fillAmount = currentHealth / maxHealth;

        if (canPlayAnim)
        {
            anim.SetTrigger("Damage");
            StartCoroutine(AntiSpamAnimation());
        }

        if (currentHealth <= 0)
        {
            Instantiate(playerExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private IEnumerator AntiSpamAnimation()
    {
        canPlayAnim = false;
        yield return new WaitForSeconds(0.15f);
        canPlayAnim = true;
    }
}
