using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Meteor : Enemy
{
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float rotateSpeed;
    private float speed;
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        rb.velocity = Vector2.down * speed;
        rotateSpeed *= Random.Range(0.5f, 1.5f);
    }

    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    public override void HurtSequence()
    {
        
    }

    public override void DeathSequence()
    {
        Instantiate(enemyExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D otherColl) 
    {
        if (otherColl.CompareTag("Player"))
        {
            PlayerStats playerStats = otherColl.GetComponent<PlayerStats>();
            playerStats.PlayerTakeDamage(dmg);
            Instantiate(enemyExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
