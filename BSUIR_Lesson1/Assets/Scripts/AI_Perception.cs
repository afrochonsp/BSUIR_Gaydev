using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Perception : MonoBehaviour
{
    [SerializeField] float sightRadius = 10;
    [SerializeField] float sightConeAngle = 90;
    [SerializeField] float lossSightDistance = 20;
    [SerializeField] float alwaysSightDistance = 5;
    public float SightConeAngle { get { return sightConeAngle; } private set { sightConeAngle = value; } }
    NPC npc;

    void Start()
    {
        npc = GetComponent<NPC>();
    }

    void Update()
    {
        float distance = 0;
        if (npc.target)
        {
            distance = Vector3.Distance(npc.transform.position, npc.target.transform.position);
        }
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, sightRadius, transform.forward);
        foreach (RaycastHit hit in hits)
        {
            if (hit.transform.GetComponent<FirstPersonCharacter>() && Physics.Linecast(transform.position, hit.transform.position))
            {
                float angle = Vector3.SignedAngle((hit.transform.position - transform.position).normalized, transform.forward, Vector3.up);
                if (Mathf.Abs(angle) < SightConeAngle / 2)
                {
                    npc.OnPerceptionUpdate(hit.transform.GetComponent<Character>());
                    return;
                }
                else if (npc.target && distance > alwaysSightDistance)
                {
                    npc.OnPerceptionUpdate(null);
                }
                return;
            }
        }
        if (npc.target)
        {
            if (distance > lossSightDistance)
            {
                npc.OnPerceptionUpdate(null);
            }
        }
    }
}