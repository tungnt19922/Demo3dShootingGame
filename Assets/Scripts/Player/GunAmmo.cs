using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAmmo : MonoBehaviour
{
    public int magSize;
    public Shooting shooting;
    public Animator anim;
    public AudioSource[] reloadSounds;

    private int _loadedAmmo;

    public int loadedAmmo
    {
        get => _loadedAmmo;
        set
        {
            _loadedAmmo = value;
            if (_loadedAmmo <= 0)
            {
                Reload();
            }
            else
            {
                UnlockShooting();
            }
        }
    }
    private void Start() 
    {
        RefillAmmo();
        anim = GetComponent<Animator>();
    } 

    public void SingleFireAmmoCounter() => loadedAmmo--;

    private void LookShooting() => shooting.enabled = false;

    private void UnlockShooting() => shooting.enabled = true;

    private void OnGunSelected() => UpdateShootingLock();

    private void UpdateShootingLock() => shooting.enabled = _loadedAmmo > 0;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }
    private void Reload()
    {
        anim.SetTrigger("Reload");
        LookShooting();
    }

    private void AddAmmo() => RefillAmmo();
    private void RefillAmmo()
    {
        loadedAmmo = magSize;
    }
    public void PlayReloadPart1Sound() => reloadSounds[0].Play();
    public void PlayReloadPart2Sound() => reloadSounds[1].Play();
    public void PlayReloadPart3Sound() => reloadSounds[2].Play();
    public void PlayReloadPart4Sound() => reloadSounds[3].Play();
    public void PlayReloadPart5Sound() => reloadSounds[4].Play();



}
