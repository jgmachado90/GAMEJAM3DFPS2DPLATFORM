using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    public Transform nextScene;
    public Transform nextSpawn;

    private move player;
    public move Player => player;

    private void Awake()
    {
        // in children to get inactive
        player = transform.parent.GetComponentInChildren<move>(true);
    }

    public void CameraChange(Transform lastPlayerTransform)
    {
        transform.parent.gameObject.SetActive(false);
        nextScene.gameObject.SetActive(true);

        nextScene.GetComponentInChildren<move>(true).transform.position = new Vector3(nextSpawn.position.x, lastPlayerTransform.position.y, nextSpawn.position.z);
    }   
}
