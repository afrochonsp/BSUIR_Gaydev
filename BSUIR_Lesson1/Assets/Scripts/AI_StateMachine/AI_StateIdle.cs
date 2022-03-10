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
        if (npc.target)
        {
            float angle = Vector3.SignedAngle((npc.target.transform.position - npc.transform.position).normalized, npc.transform.forward, Vector3.up);
            float sightConeAngle = npc.GetComponent<AI_Perception>().SightConeAngle;
            if (Mathf.Abs(angle) > sightConeAngle / 4)
            {
                manager.ChangeState(manager.stateRotate);
            }
        }
    }
}
