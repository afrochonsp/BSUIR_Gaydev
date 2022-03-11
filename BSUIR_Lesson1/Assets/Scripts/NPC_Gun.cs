using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Gun : Gun
{
    [SerializeField] GameObject spawnPoint;

    protected override Ray MakeRay()
    {
        return new Ray(spawnPoint.transform.position, transform.forward);
    }
}