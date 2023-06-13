using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    protected float projectileSpeed;
    protected float lifetime;

    protected Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        SetProperties();
        Invoke("Destroy", lifetime);
    }

    protected virtual void SetProperties()
    {
        projectileSpeed = 1000;
        lifetime = 2;

        rb.AddForce(transform.forward * projectileSpeed);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
