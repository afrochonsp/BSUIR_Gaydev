using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleeding : MonoBehaviour
{
    public ParticleSystem system;

    void Update()
    {
        if (Input.GetAxis("Jump") == 1)
        {
            //Spawn 1000 particles in 1 frame
            system.Emit(1000);
            
        }
    }
}
