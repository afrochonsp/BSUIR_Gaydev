using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_StateShoot : AI_State
{
    public override void EnterState(AI_StateManager manager, NPC npc)
    {
        npc.animator.SetBool("Shoot", true);
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
                npc.animator.SetBool("Shoot", false);
            }
        }
        else
        {
            manager.ChangeState(manager.stateMove);
            npc.animator.SetBool("Shoot", false);
        }
        npc.GetComponent<Gun>().Shot();
    }
}
