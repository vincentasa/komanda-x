using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject Destroyparticles;
    public int hp;

    public AudioSource destroy;
    public AudioSource hit;

    public void Damage()
    {
        hit.Play();
        if (hp <= 0)
        {
            Die();
            destroy.Play();
        }
    }

    public void Die()
    {
        Destroy(gameObject);

        Instantiate(Destroyparticles, transform.position, transform.rotation);
    }
}
