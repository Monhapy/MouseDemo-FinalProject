using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEnemy : MonoBehaviour
{
    public Animator enemyAnimator;
    public int health;
    private MeleeStateMachine _stateMachine;

    private void Start()
    {
        _stateMachine = gameObject.GetComponent<MeleeStateMachine>();
    }

    public void Hit()
    {
        Debug.Log("Hitted");
        Rigidbody rb = GetComponent<Rigidbody>();
        
        rb.AddForce(new Vector3(5f,0f,0f),ForceMode.Impulse);
        enemyAnimator.SetTrigger("Damage");
        
    }

    private void Update()
    {
        if (health<=0)
        {
            _stateMachine.currentState = MeleeStateMachine.EnemyStates.Death;
            //enemyAnimator.SetBool("Dead",true);
            Debug.Log("EnemyDead");
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        
    }
}
