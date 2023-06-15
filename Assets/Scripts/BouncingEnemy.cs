using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingEnemy : BaseEnemy //POLYMORPHISM
{
    private Rigidbody rb;

    protected override void Start() //INHERITANCE
    {
        rb = GetComponent<Rigidbody>();

        base.Start();
        desc = "BouncingEnemy inherits BaseEnemy.";
    }

    protected override IEnumerator Move() //INHERITANCE
    {
        float timer = 0;
        while(true)
        {
            rb.AddForce((transform.forward + transform.up).normalized * 800, ForceMode.Impulse);
            timer = 0;
            while(timer < 1.5f)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            timer = 0;
            rb.AddForce((transform.forward + transform.up).normalized * 800, ForceMode.Impulse);
            while(timer < 1.5f)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            timer = 0;
            rb.AddForce((transform.forward + transform.up).normalized * 800, ForceMode.Impulse);
            while(timer < 1.5f)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            transform.Rotate(new Vector3(0, 180, 0));
            timer = 0;
        }
    }
}
