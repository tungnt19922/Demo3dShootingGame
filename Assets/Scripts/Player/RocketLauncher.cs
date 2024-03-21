using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Shooting
{
    private const int LeftMouseButton = 0;
    public GameObject bulletPrefab;
    public Transform firingPos;
    public float bulletSpeed;
    public AudioSource shootingSound;
    public Animator anim;

    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            ShootBullet();
            AddProjectile();
        }
    }

    private void ShootBullet() => anim.SetTrigger("Shoot");
    public void PlayFireSound() => shootingSound.Play();

    public void AddProjectile()
    {
        GameObject bullet = Instantiate(bulletPrefab, firingPos.position, firingPos.rotation);
        bullet.GetComponent<Rigidbody>().velocity = firingPos.right * bulletSpeed;
    }
}
