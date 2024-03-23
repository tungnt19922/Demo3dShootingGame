using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class ZombieMovement : MonoBehaviour
{
    public Transform playerFoot;
    public Animator anim;
    public NavMeshAgent agent;
    public float reachingRadius;
    public UnityEvent onDestinationReached;
    public UnityEvent onStartMoving;

    public bool _isMovingValue;
    public bool IsMoving
    {
        get => _isMovingValue;
        private set
        {
            if (_isMovingValue == value) return;
            _isMovingValue = value;
            OnIsMovingValueChanged();
        }
    }

    private void OnIsMovingValueChanged()
    {
        agent.isStopped = !_isMovingValue;
        anim.SetBool("isWalking", _isMovingValue);
        if (_isMovingValue )
        {
            onStartMoving.Invoke(); 
        }
        else
        {
            onDestinationReached.Invoke();
        }
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, playerFoot.position);
        IsMoving = distance > reachingRadius;
        if ( IsMoving )
        {
            agent.SetDestination(playerFoot.position);
        }
        //if (distance > reachingRadius)
        //{
        //    agent.isStopped = false;
        //    agent.SetDestination(playerFoot.position);
        //    anim.SetBool("IsWalking", true);
        //}
        //else
        //{
        //    agent.isStopped = true;
        //    anim.SetBool("IsWalking", false);
        //}
    }
}
