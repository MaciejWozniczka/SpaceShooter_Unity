using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject laserBullet;
    [SerializeField] private Transform basicShootPoint;
    [SerializeField] private float shootingInterval;
    private float intervalReset;
    void Start()
    {
        intervalReset = shootingInterval;
    }

    void Update()
    {
        shootingInterval -= Time.deltaTime;

        if (shootingInterval <= 0)
        {
            Shoot();
            shootingInterval = intervalReset;
        }
    }

    private void Shoot()
    {
        Instantiate(laserBullet, basicShootPoint.position, Quaternion.identity);
    }
}
