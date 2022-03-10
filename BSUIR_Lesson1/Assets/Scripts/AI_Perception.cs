using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Perception : MonoBehaviour
{
    [SerializeField] float sightRadius = 50;
    [SerializeField] float sightConeAngle = 90;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, sightRadius, transform.forward);
        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                if (hit.transform.GetComponent<FirstPersonCharacter>())
                {
                    float angle = Vector3.SignedAngle((hit.transform.position - transform.position).normalized, transform.forward, Vector3.up);
                    if ((angle > 0 && angle < sightConeAngle / 2) || (angle < 0 && angle > -sightConeAngle / 2))
                    {
                        print(angle + 180);
                    }
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, sightRadius);
    }
}
