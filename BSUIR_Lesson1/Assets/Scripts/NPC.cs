using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AI_Perception))]
public class NPC : Character
{
    public Character target { get; private set; }
    AI_Perception perception;
    void Start()
    {
        perception = GetComponent<AI_Perception>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPerceptionUpdate(Character target, bool visible)
    {
        this.target = target;
    }
}
