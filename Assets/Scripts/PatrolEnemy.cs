using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : BaseEnemy //POLYMORPHISM
{
    private Rigidbody rb;

    protected override void Start() //INHERITANCE
    {
        rb = GetComponent<Rigidbody>();

        base.Start();
        desc = "PatrolEnemy inherits BaseEnemy.";
    }

    protected override IEnumerator Move() //INHERITANCE
    {
        float timer = 0f;
        while(true)
        {            
            while(timer < 1.5f)
            {
                timer += Time.deltaTime;
                rb.AddForce(transform.forward * 2500);
                yield return null;
            }
            timer = 0;
            while(timer < 1)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            transform.Rotate(new Vector3(0, 180, 0));
            timer = 0;
        }  
    }
}
