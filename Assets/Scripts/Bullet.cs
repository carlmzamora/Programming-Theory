using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float projectileSpeed;
    [SerializeField] protected float lifetime;
    private Rigidbody rb;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * projectileSpeed);

        Invoke("Destroy", lifetime);
    }

    protected virtual void Destroy()
    {
        Destroy(gameObject);
    }
}
