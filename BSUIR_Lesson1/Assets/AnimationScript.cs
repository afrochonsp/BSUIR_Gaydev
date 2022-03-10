using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public Animation anim;
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        anim.Play("idle");
    }
}
