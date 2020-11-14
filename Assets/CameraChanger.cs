using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    public move lastPlayer;
    public move nextPlayer;

    public Camera lastCamera;
    public Camera nextCamera;

    public Transform lastSpawn;
    public Transform nextSpawn;

    public void CameraChange(Transform lastPlayerTransform)
    {
        lastCamera.gameObject.SetActive(false);
        nextCamera.gameObject.SetActive(true);
        
        Camera aux = lastCamera;

        lastCamera = nextCamera;
        nextCamera = aux;

        lastPlayer = lastPlayerTransform.GetComponent<move>();

        nextPlayer.gameObject.SetActive(true);
        nextPlayer.transform.position = new Vector3(nextSpawn.position.x, lastPlayerTransform.position.y, nextSpawn.position.z);

        Transform auxSpawn = nextSpawn;
        nextSpawn = lastSpawn;
        lastSpawn = auxSpawn;
        
        
        move auxplayer = nextPlayer;
        nextPlayer = lastPlayer;
        lastPlayer = auxplayer;



        


    }

}
