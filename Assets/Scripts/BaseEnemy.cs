using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] private GameObject hitTextUI;
    private GameObject descTextGO;
    private TextMeshProUGUI descText;

    protected float moveRange = 10;
    protected float moveInterval = 1.5f;
    protected string desc;

    protected virtual void Start()
    {
        StartCoroutine(Move());
        descTextGO = GameObject.Find("DescriptionText");
        descText = descTextGO.GetComponent<TextMeshProUGUI>();
        desc = "BaseEnemy inherits MonoBehaviour.";
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
            TakeDamage(bulletGO.GetComponent<BaseBullet>().Damage, col.GetContact(0).point);
        }
    }

    void TakeDamage(int amount, Vector3 collisionPt)
    {
        HitTextUI text = Instantiate(hitTextUI, collisionPt, hitTextUI.transform.rotation).GetComponent<HitTextUI>();
        text.SetAmount((-amount).ToString());
    }

    void ToggleDescription(bool toggle)
    {
        descText.gameObject.SetActive(toggle);
        if(toggle)
        {
            descText.text = desc;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            ToggleDescription(true);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            ToggleDescription(false);
        }
    }
}
