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
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, sightRadius, transform.forward, out hit, 0))
        {
            print(hit.transform);
            // = hit.distance;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, sightRadius);
    }
}
