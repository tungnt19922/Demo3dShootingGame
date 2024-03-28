using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealthPoint;
    public Animator anim;
    public UnityEvent onDie;
    public int healthPoint;
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
        if (anim)
            anim.SetTrigger("Die");

        onDie.Invoke();

    }

}
