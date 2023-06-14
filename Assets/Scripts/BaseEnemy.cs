using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    protected float moveRange = 10;
    protected float moveInterval = 1.5f;

    protected virtual void Start()
    {
        StartCoroutine(Move());
    }

    protected virtual IEnumerator Move()
    {
        while(true)
        {
            yield return new WaitForSeconds(moveInterval);
            transform.Translate(transform.right * moveRange);
            yield return new WaitForSeconds(moveInterval);
            transform.Translate(-transform.right * moveRange);
        }        
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Bullet"))
        {
            GameObject bulletGO = col.gameObject;
            Destroy(bulletGO);
            TakeDamage(bulletGO.GetComponent<BaseBullet>().Damage);
        }
    }

    void TakeDamage(int amount)
    {
        Debug.Log(amount);
    }
}
