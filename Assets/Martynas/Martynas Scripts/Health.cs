using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject Destroyparticles;
    public int hp;

    private AudioSource source;

    public AudioClip destroy;
    public AudioClip hit;

    private void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }
    public void Damage()
    {
        source.PlayOneShot(hit);
        if (hp <= 0)
        {
            source.PlayOneShot(destroy);
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);

        Instantiate(Destroyparticles, transform.position, transform.rotation);
    }
}
