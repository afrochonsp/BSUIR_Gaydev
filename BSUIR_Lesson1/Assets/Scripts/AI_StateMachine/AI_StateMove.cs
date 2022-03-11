using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_StateMove : AI_State
{
    NavMeshAgent navMeshAgent;
    float distance = 30;
    public override void EnterState(AI_StateManager manager, NPC npc)
    {
        navMeshAgent = npc.GetComponent<NavMeshAgent>();
        navMeshAgent.isStopped = false;
        Vector3 pos = RandomNavSphere(npc.transform.position, distance);
        navMeshAgent.SetDestination(pos);
    }

    Vector3 RandomNavSphere(Vector3 position, float distance)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;
        randomDirection += position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, distance, -1);
        return navHit.position;
    }

    public override void UpdateState(AI_StateManager manager, NPC npc)
    {
        if (npc.target)
        {
            navMeshAgent.isStopped = true;
            manager.ChangeState(manager.stateRotate);
        }
        if (!navMeshAgent.hasPath)
        {
            EnterState(manager, npc);
        }
    }
}
