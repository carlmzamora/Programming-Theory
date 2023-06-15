using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitTextUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hitText;

    void Start()
    {
        Invoke("DestroyThis", 1);
    }

    // Update is called once per frame
    void Update()
    {
        float y = transform.position.y;
        y += 0.01f;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

    void DestroyThis()
    {
        Destroy(this.gameObject);
    }

    public void SetAmount(string amount)
    {
        hitText.text = amount;
    }
}
