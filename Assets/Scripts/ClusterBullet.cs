using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClusterBullet : LobBullet
{
    private bool isSubBullet = false;

    protected override void SetProperties()
    {
        base.SetProperties();

        if(isSubBullet)
        {
            rb.AddForce(((Quaternion.Euler(0, Random.Range(0, 360), 0) * transform.forward) + transform.up).normalized * 100);
        }
    }

    void Split()
    {
        if(!isSubBullet) //allowSplit
        {
            int splitCount = 5;
            for(int i = 0; i < splitCount; i++)
            {
                Vector3 position = (Random.insideUnitSphere * 2) + transform.position + Vector3.up;
                ClusterBullet subBullet = Instantiate(gameObject, position, transform.rotation).GetComponent<ClusterBullet>();
                subBullet.transform.localScale = Vector3.one * 0.3f;
                subBullet.SetAsSubBullet();
            }

            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Split();
    }

    public void SetAsSubBullet()
    {
        isSubBullet = true;
    } 
}
