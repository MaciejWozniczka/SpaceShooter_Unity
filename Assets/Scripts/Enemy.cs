using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;
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
