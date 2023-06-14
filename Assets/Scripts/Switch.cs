using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Switch : MonoBehaviour
{
    [SerializeField] private GameObject uiPopUp;
    [SerializeField] private GameObject bulletPrefabToUse;
    bool inRange = false;

    void Start()
    {
        uiPopUp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && inRange)
        {
            SwitchProjectile();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(!col.gameObject.CompareTag("Player")) return;
        uiPopUp.SetActive(true);
        inRange = true;
    }
    
    void OnTriggerExit(Collider col)
    {
        if(!col.gameObject.CompareTag("Player")) return;
        uiPopUp.SetActive(false);
        inRange = false;
    }

    protected virtual void SwitchProjectile()
    {
        Player.Instance.activeBulletPrefab = bulletPrefabToUse;
    }
}
