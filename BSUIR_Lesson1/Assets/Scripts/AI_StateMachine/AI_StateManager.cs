using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NPC))]
public class AI_StateManager : MonoBehaviour
{
    NPC npc;
    AI_State currentState;
    AI_StateIdle stateIdle = new AI_StateIdle();
    AI_StateMove stateMove = new AI_StateMove();
    AI_StateRotate stateRotate = new AI_StateRotate();

    // Start is called before the first frame update
    void Start()
    {
        npc = GetComponent<NPC>();
        currentState = stateIdle;
        currentState.EnterState(this, npc);
    }

    // Update is called once per frame
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
