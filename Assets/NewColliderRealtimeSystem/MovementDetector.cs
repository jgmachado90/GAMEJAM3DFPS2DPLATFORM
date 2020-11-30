using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDetector : MonoBehaviour
{

    public Vector3 lastPosition;
    public Quaternion lastRotation;

    public Vector3 RotateAmount;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
        lastRotation = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(RotateAmount * Time.deltaTime);

        if (lastPosition != transform.position || lastRotation != transform.rotation)
        {
            lastPosition = transform.position;
            lastRotation = transform.rotation;
            MeshColliderGenerator.instance.UpdateMeshCollider();
        }
    }
}
