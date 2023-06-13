using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobBullet : BaseBullet
{
    // Start is called before the first frame update
    protected override void SetProperties()
    {
        projectileSpeed = 400;
        lifetime = 4;

        Vector3 direction = (transform.forward + transform.up).normalized;
        rb.useGravity = true;        
        rb.AddForce(direction * projectileSpeed);
    }
}
