using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform target;
    public Transform currentTarget;


    public float speed = 1.0f;
    private void Awake()
    {
        GetComponent<BoxCollider>().enabled = false;
        currentTarget = target;

    }
    public void Action()
    {
        GetComponent<BoxCollider>().enabled = false;
        currentTarget = target;
    }



    private void Update()
    {
        // Move our position a step closer to the target.
        float step = speed * Time.deltaTime; // calculate distance to move
        Debug.Log("step = " + step);
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, currentTarget.position) < 0.001f)
        {
            Debug.Log("terminou");
            // Swap the position of te cylinder.
            //currentTarget.position *= -1.0f;
        }
    }
}
