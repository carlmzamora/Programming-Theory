using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform spawnPt;
    [SerializeField] private GameObject bulletPrefab;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Move()
    {
        //movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput).normalized;

        rb.AddForce(direction * moveSpeed);

        //rotation
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, new Vector3(0, -1.1f, 0));
        float rayLength;

        if(groundPlane.Raycast(mouseRay, out rayLength))
        {
            Vector3 pointToLook = mouseRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, spawnPt.position, spawnPt.transform.rotation);
    }
}
