using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_StateRotate : AI_State
{
    public override void EnterState(AI_StateManager manager, NPC npc)
    {
        npc.transform.rotation = Quaternion.EulerAngles(0, 1, 0);
        //npc.transform.LookAt(npc.transform);
        manager.ChangeState(new AI_StateIdle());
    }

    public override void UpdateState(AI_StateManager manager, NPC npc)
    {

    }
}
