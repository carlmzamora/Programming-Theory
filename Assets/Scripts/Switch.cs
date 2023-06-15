using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Switch : MonoBehaviour
{
    [SerializeField] private GameObject uiPopUp;
    [SerializeField] private GameObject bulletPrefabToUse;

    private GameObject descTextGO;
    private TextMeshProUGUI descText;

    bool inRange = false;

    void Start()
    {
        uiPopUp.SetActive(false);
        descTextGO = GameObject.Find("DescriptionText");
        descText = descTextGO.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && inRange)
        {
            SwitchProjectile();
        }
    }

    void ToggleDescription(bool toggle)
    {
        descText.gameObject.SetActive(toggle);
        if(toggle)
        {
            string desc = "Shoot BaseBullet that inherits MonoBehaviour.";

            if(bulletPrefabToUse.GetComponent<LobBullet>() != null)
            {
                desc = "Shoot LobBullet that inherits BaseBullet.";
            }
            else if(bulletPrefabToUse.GetComponent<SlowBullet>() != null)
            {
                desc = "Shoot SlowBullet that inherits BaseBullet.";
            }
            else if(bulletPrefabToUse.GetComponent<ClusterBullet>() != null)
            {
                desc = "Shoot Cluster that inherits LobBullet.";
            }

            descText.text = desc;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(!col.gameObject.CompareTag("Player")) return;
        uiPopUp.SetActive(true);
        inRange = true;

        ToggleDescription(true);
    }
    
    void OnTriggerExit(Collider col)
    {
        if(!col.gameObject.CompareTag("Player")) return;
        uiPopUp.SetActive(false);
        inRange = false;

        ToggleDescription(false);
    }

    protected virtual void SwitchProjectile()
    {
        Player.Instance.activeBulletPrefab = bulletPrefabToUse;
    }
}
