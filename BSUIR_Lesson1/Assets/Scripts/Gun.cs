using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class Gun : MonoBehaviour
{
    [SerializeField] float damage = 10;
    [SerializeField] float recharge = 0.1f;
    [SerializeField] AudioClip sound;
    [SerializeField] GameObject bloodParticle;
    AudioSource audioSource;
    float lastShotTime;

    protected void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    protected abstract Ray MakeRay();

    public void Shot()
    {
        if (Time.time - lastShotTime > recharge)
        {
            lastShotTime = Time.time;
        }
        else
        {
            return;
        }
        audioSource.PlayOneShot(sound);
        Ray ray = MakeRay();
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            Character character;
            if (character = hit.transform.GetComponent<Character>())
            {
                character.TakeDamage(damage);
                if (bloodParticle)
                {
                    bloodParticle = Instantiate(bloodParticle, hit.point, Quaternion.identity);
                }
            }
        }
    }
}