using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NPC))]
public class AI_StateManager : MonoBehaviour
{
    NPC npc;
    public AI_State currentState;
    public AI_StateShoot stateShoot = new AI_StateShoot();
    public AI_StateMove stateMove = new AI_StateMove();
    public AI_StateRotate stateRotate = new AI_StateRotate();

    void Start()
    {
        npc = GetComponent<NPC>();
        currentState = stateMove;
        currentState.EnterState(this, npc);
    }

    void Update()
    {
        currentState.UpdateState(this, npc);
    }

    public void ChangeState(AI_State state)
    {
        currentState = state;
        state.EnterState(this, npc);
    }
}
