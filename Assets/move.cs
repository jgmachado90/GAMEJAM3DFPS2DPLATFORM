using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public float moveSpeed;
    public float maxSpeed = 3.5f;
    public float gravity;
    public float jumpSpeed;
    public Rigidbody rb;
    public bool canMove = true;
    public bool inAir = true;
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
        if (inAir)
        {
            transform.parent = null;
            rb.AddForce(-transform.up * gravity, ForceMode.Acceleration);
            transform.parent = parent;
        }
        bool leftKey = Input.GetKey(KeyCode.J);
        bool rightKey = Input.GetKey(KeyCode.L);
        bool jumpKey = Input.GetKey(KeyCode.I);

        if (leftKey)
        {

            transform.parent = null;
            rb.AddForce(-transform.right * moveSpeed, ForceMode.Acceleration);
            transform.parent = parent;
            //transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        if (rightKey)
        {
            transform.parent = null;
            rb.AddForce(transform.right * moveSpeed, ForceMode.Acceleration);
            transform.parent = parent;
            //transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        if (jumpKey)
        {
            if (!inAir)
            {
                transform.parent = null;
                rb.AddForce(transform.up * jumpSpeed, ForceMode.Impulse);
                transform.parent = parent;
                inAir = true;
            }
        }
        if (!leftKey && !rightKey)
        {
            var newVelocity = rb.velocity;
            var newY = newVelocity.y;
            // diminui
            newVelocity = Vector3.Lerp(newVelocity, Vector3.zero, 0.2f);
            if (inAir)
                newVelocity.y = newY;
            rb.velocity = newVelocity;
        }

        // capa a velocidade
        var y = rb.velocity.y;
        var velocity = rb.velocity;
        if (inAir)
        {
            velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);
            rb.velocity = velocity;
        }
        else
        {
            rb.velocity = rb.velocity.normalized * Mathf.Min(rb.velocity.magnitude, maxSpeed);
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
            inAir = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.transform.tag == "Floor")
        {
            inAir = true;
        }
    }


}
