using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private AudioSource source;
    public AudioClip shoot;
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform gunTransform;
    public bool canFire;
    private float timer;
    public float fireRate;
    private void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > fireRate)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            source.PlayOneShot(shoot);
            Instantiate(bullet, gunTransform.position, gunTransform.rotation);
        }
    }
}
