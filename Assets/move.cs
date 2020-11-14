using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public float moveSpeed;
    public float gravity;
    public float jumpSpeed;
    public Rigidbody rb;
    public bool canMove = true;
    public bool isFalling = true;
    private Transform parent;
    

    private void Awake()
    {
        parent = transform.parent;
    }

    private void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFalling)
        {
            transform.parent = null;
            rb.AddForce(-transform.up * gravity, ForceMode.Acceleration);
            transform.parent = parent;
        }
        if (Input.GetKey(KeyCode.J))
        {
     
            transform.parent = null;
            rb.AddForce(-transform.right * moveSpeed, ForceMode.Acceleration);
            transform.parent = parent;
            //transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }

        if (Input.GetKey(KeyCode.L))
        {
            transform.parent = null;         
            rb.AddForce(transform.right * moveSpeed, ForceMode.Acceleration);
            transform.parent = parent;
            //transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            transform.parent = null;
            rb.AddForce(transform.up * jumpSpeed, ForceMode.Impulse);
            transform.parent = parent;
            isFalling = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        other.GetComponent<CameraChanger>().CameraChange(transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "CameraChanger")
        {

            /*if (this.GetComponent<Rigidbody>().velocity.x > 0)
            {
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                this.GetComponent<Rigidbody>().AddForce(transform.right * 4, ForceMode.Impulse);
            }
            if (this.GetComponent<Rigidbody>().velocity.x < 0)
            {
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                this.GetComponent<Rigidbody>().AddForce(-transform.right * 4, ForceMode.Impulse);
            }
          */
            collision.transform.GetComponent<CameraChanger>().CameraChange(transform);
        }

        if(collision.transform.tag == "Floor")
        {
            isFalling = false;
        }


    }
}
