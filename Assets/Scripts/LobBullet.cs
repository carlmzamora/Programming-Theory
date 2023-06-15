using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobBullet : BaseBullet //POLYMORPHISM
{
    // Start is called before the first frame update
    protected override void SetProperties() //INHERITANCE
    {
        projectileSpeed = 400;
        lifetime = 4;
        damage = 25;

        Vector3 direction = (transform.forward + transform.up).normalized;
        rb.useGravity = true;        
        rb.AddForce(direction * projectileSpeed);
    }
}
