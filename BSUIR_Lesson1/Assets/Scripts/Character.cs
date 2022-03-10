using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public abstract class Character : MonoBehaviour
{
    [SerializeField] protected float HP = 100;
    public abstract void TakeDamage(float damage);
}
