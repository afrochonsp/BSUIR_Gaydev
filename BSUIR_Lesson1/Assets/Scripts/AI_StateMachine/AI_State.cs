using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AI_State
{
    public abstract void EnterState(AI_StateManager manager, NPC npc);
    public abstract void UpdateState(AI_StateManager manager, NPC npc);
}
