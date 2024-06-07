using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedCat : MonoBehaviour
{
    
    public Transform player;
    public float attackDistance = 5.0f;
    public float chaseDistance = 10.0f;
    public float chaseSpeed = 5.0f;
    public float attackDelay = 2.0f;
    public int damage = 10;
    public Animator enemyAnim;
    private float _lastAttackTime;
    
    void OnDrawGizmos()
    {
        // Kovalama mesafesi için mavi bir çember çiz
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);

        // Saldırı mesafesi için kırmızı bir çember çiz
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
    
}
