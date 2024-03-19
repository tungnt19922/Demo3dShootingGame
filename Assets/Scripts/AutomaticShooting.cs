using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AutomaticShooting : Shooting
{
    public Animator anim;
    public int rpm;

    public GameObject hitMarkerPrefab;
    public Camera aimingCamera;
    public LayerMask layerMask;

    public AudioSource shootSound;
    public UnityEvent onShoot;

    private float lastShot;
    private float interval;

    void Start() => interval = 60f / rpm;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            UpdateFiring();
        }
    }

    private void UpdateFiring()
    {
        if (Time.time - lastShot >= interval)
        {
            Shoot();
            lastShot = Time.time;
        }
    }

    private void Shoot()
    {
        //anim.Play("Shoot", layer: -1, normalizedTime: 0);
        shootSound.Play();
        PerformRaycasting();
        onShoot.Invoke();
    }

    private void PerformRaycasting()
    {
        Ray aimingRay = new Ray(aimingCamera.transform.position, aimingCamera.transform.forward);
        if (Physics.Raycast(aimingRay, out RaycastHit hitInfo, 1000f, layerMask))
        {
            Quaternion effectRotation = Quaternion.LookRotation(hitInfo.normal);
            Instantiate(hitMarkerPrefab, hitInfo.point, effectRotation);
        }
    }
}
