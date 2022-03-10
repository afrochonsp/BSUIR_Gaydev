using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_StateIdle : AI_State
{
    public override void EnterState(AI_StateManager manager, NPC npc)
    {

    }

    public override void UpdateState(AI_StateManager manager, NPC npc)
    {
        //Debug.Log(angle + 180);
        if (npc.target)
        {
            float angle = Vector3.SignedAngle((npc.target.transform.position - npc.transform.position).normalized, npc.transform.forward, Vector3.up);
            if (!(angle > 0 && angle < 20) || (angle < 0 && angle > 20))
            manager.ChangeState(new AI_StateRotate());
            //Debug.Log(angle + 180);
        }
    }
}
