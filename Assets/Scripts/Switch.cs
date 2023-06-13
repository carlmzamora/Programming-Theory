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

    void OnTriggerEnter()
    {
        uiPopUp.SetActive(true);
        inRange = true;
    }
    
    void OnTriggerExit()
    {
        uiPopUp.SetActive(false);
        inRange = false;
    }

    protected virtual void SwitchProjectile()
    {
        Player.Instance.activeBulletPrefab = bulletPrefabToUse;
    }
}
