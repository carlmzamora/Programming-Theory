using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    float moveRange = 10;
    float moveInterval = 1.5f;

    void Start()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while(true)
        {
            yield return new WaitForSeconds(moveInterval);
            transform.Translate(transform.right * moveRange);
            yield return new WaitForSeconds(moveInterval);
            transform.Translate(-transform.right * moveRange);
        }        
    }
}
