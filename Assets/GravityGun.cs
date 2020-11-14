using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    public Camera cam;
    public float maxGrabDistance = 10f, throwForce = 20f, lerpSpeed = 10f;
    public Transform objectHolder;

    public Rigidbody grabbedRB;

    private void Start()
    {
        
    }

    private void Update()
    {

        if (grabbedRB)
        {
            grabbedRB.MovePosition(objectHolder.transform.position);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (grabbedRB)
            {
                grabbedRB.isKinematic = false;
                grabbedRB = null;
            }
            else
            {
                RaycastHit hit;
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
                if (Physics.Raycast(ray, out hit, maxGrabDistance))
                {
                    
                    grabbedRB = hit.collider.gameObject.GetComponent<Rigidbody>();
                    Debug.Log("raycasthit  = " + hit.collider.gameObject);
                    if (grabbedRB)
                    {
                        grabbedRB.isKinematic = true;
                    }
                }
            }
        }
    }

}
