using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(AI_Perception))]
[RequireComponent(typeof(NavMeshAgent))]
public class NPC : Character
{
    public Character target { get; private set; }
    AI_Perception perception;
    public Animator animator { get; private set; }
    NavMeshAgent navMeshAgent;
    void Start()
    {
        perception = GetComponent<AI_Perception>();
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(animator)
        {
            animator.SetFloat("Speed", navMeshAgent.velocity.magnitude / navMeshAgent.speed);
        }
    }

    public void OnPerceptionUpdate(Character target)
    {
        this.target = target;
    }

    public override void TakeDamage(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
