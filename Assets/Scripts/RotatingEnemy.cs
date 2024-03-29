using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingEnemy : BaseEnemy //POLYMORPHISM
{
    protected override void Start() //INHERITANCE
    {
        base.Start();
        desc = "RotatingEnemy inherits BaseEnemy.";
    }

    protected override IEnumerator Move() //INHERITANCE
    {
        float timer = 0;
        while(true)
        {
            while(timer < 2)
            {
                timer += Time.deltaTime;
                transform.Rotate(0, 0.2f, 0);
                yield return null;
            }
            timer = 0;
            while(timer < 1)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            timer = 0;
            while(timer < 2)
            {
                timer += Time.deltaTime;
                transform.Rotate(0, -0.2f, 0);
                yield return null;
            }
            timer = 0;
            while(timer < 1)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            timer = 0;
        }
    }
}
