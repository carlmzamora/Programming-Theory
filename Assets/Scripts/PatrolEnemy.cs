using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : BaseEnemy
{
    private Rigidbody rb;

    protected override void Start()
    {
        rb = GetComponent<Rigidbody>();

        base.Start();
        StartCoroutine(TurnCountdown());
    }

    protected override IEnumerator Move()
    {
        while(true)
        {
            rb.AddForce(transform.forward * 1000);
            yield return new WaitForEndOfFrame();
        } 
    }

    IEnumerator TurnCountdown()
    {
        while(true)
        {
            yield return new WaitForSeconds(2);
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}
