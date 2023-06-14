using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBullet : BaseBullet
{
    // Start is called before the first frame update
    protected override void SetProperties()
    {
        projectileSpeed = 250;
        lifetime = 5;
        damage = 50;

        rb.AddForce(transform.forward * projectileSpeed);
    }
}
