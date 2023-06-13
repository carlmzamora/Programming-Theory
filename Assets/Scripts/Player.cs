using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform spawnPt;
    [SerializeField] private GameObject baseBulletPrefab;
    private Rigidbody rb;

    public GameObject activeBulletPrefab;

    public static Player Instance { get; private set; }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Instance = this;
        activeBulletPrefab = baseBulletPrefab;
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
        Instantiate(activeBulletPrefab, spawnPt.position, spawnPt.transform.rotation);
    }
}
