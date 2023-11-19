using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float dmg;
    void Start()
    {
        
    }

    public void TakDamage(float damage)
    {
        health -= damage;
        HurtSequence();

        if (health <= 0)
        {
            DeathSequence();
        }
    }

    public virtual void HurtSequence()
    {
    }
    public virtual void DeathSequence()
    {
    }
}
