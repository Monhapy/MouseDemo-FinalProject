using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEnemy : MonoBehaviour
{
    public Animator enemyAnimator;
    public int health;
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
            enemyAnimator.SetTrigger("Dead");
            Debug.Log("EnemyDead");
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        
    }
}
