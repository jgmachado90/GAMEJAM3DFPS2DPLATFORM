using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool opened = false;
    public Transform target;
    public Transform currentTarget;
    public Transform closedTarget;
    public bool canAct = true;

    public ActionObject actionObject;

    public float speed = 1.0f;
    private void Awake()
    {
        //GetComponent<BoxCollider>().enabled = false;
        //currentTarget = target;

    }

    private void Start() {
        if (actionObject != null){
            actionObject.onActive += Action;
            actionObject.onDisactive += Action;
        }
    }

    public void Action()
    {
        Debug.Log("Dooraction");
        if(opened == true)
        {
            canAct = false;
            GetComponent<BoxCollider>().enabled = false;
            Debug.Log("closed target");
            currentTarget = closedTarget;
            opened = false;
          
        }
        else if(opened == false)
        {
            canAct = false;
            GetComponent<BoxCollider>().enabled = false;
            currentTarget = target;
            opened = true;
        }
       
    }



    private void Update()
    {
        // Move our position a step closer to the target.
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, currentTarget.position) < 0.001f)
        {
            canAct = true;
            //Debug.Log("terminou");
            // Swap the position of te cylinder.
            //currentTarget.position *= -1.0f;
        }
    }
}
