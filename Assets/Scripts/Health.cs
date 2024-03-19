using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealthPoint;
    public Animator anim;

    [SerializeField] private int healthPoint;
    private bool isDead => healthPoint <= 0;

    private void Start() => healthPoint = maxHealthPoint;

    public void TakeDamage(int damage)
    {
        if (isDead) return;
        healthPoint -= damage;
        if (isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        anim.SetTrigger("Die");
    }
}
