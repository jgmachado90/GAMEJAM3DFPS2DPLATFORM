using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOX2D3D : MonoBehaviour
{
    public List<Transform> objectsToDeactivate;

    public void OnDeactivate()
    {
        foreach(Transform t in objectsToDeactivate)
        {
            t.gameObject.SetActive(false);
        }
    }

    public void OnActivate()
    {
        foreach (Transform t in objectsToDeactivate)
        {
            t.gameObject.SetActive(true);
        }
    }
}
