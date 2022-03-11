using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_StateRotate : AI_State
{
    Quaternion targetRotation;
    float turningRate = 90;
    public override void EnterState(AI_StateManager manager, NPC npc)
    {
        targetRotation = Quaternion.LookRotation(npc.target.transform.position - npc.transform.position);
        targetRotation.eulerAngles = new Vector3(npc.transform.localEulerAngles.x, targetRotation.eulerAngles.y, npc.transform.localEulerAngles.z);
    }

    public override void UpdateState(AI_StateManager manager, NPC npc)
    {
        npc.transform.rotation = Quaternion.RotateTowards(npc.transform.rotation, targetRotation, turningRate * Time.deltaTime);
        if(Mathf.Abs(npc.transform.localEulerAngles.y - targetRotation.eulerAngles.y) < 1)
        {
            manager.ChangeState(manager.stateShoot);
        }
    }
}
