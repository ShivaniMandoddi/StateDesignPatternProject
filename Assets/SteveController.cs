using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteveController : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerSpeed;
    public float rotationSpeed;
    public Camera cam;
    public Animator animator;
    public Transform bulletPoint;
    public GameObject bulletPrefab;
    Rigidbody rb;
    public float bulletSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal")*playerSpeed*Time.deltaTime;
        float inputZ = Input.GetAxis("Vertical")*playerSpeed*Time.deltaTime;
        transform.Translate(inputX, 0f, inputZ);
        float mouseX = Input.GetAxis("Mouse X")*rotationSpeed;
        transform.Rotate(0f, mouseX, 0f);
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;
        cam.transform.Rotate(-mouseY, 0f, 0f);
        if(Input.GetKeyDown(KeyCode.H))
        {
            animator.SetBool("IsAiming", !animator.GetBool("IsAiming"));
        }
        if(inputX!=0 || inputZ!=0)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
        if(Input.GetKeyDown(KeyCode.Space))                 // Firing 
        {
            animator.SetTrigger("IsFiring");
            GameObject temp=Instantiate(bulletPrefab, bulletPoint.position, Quaternion.identity);
            rb = temp.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.forward * bulletSpeed);

        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            animator.SetTrigger("IsReload");
        }

    }
    public void Walk()
    {

    }
}
