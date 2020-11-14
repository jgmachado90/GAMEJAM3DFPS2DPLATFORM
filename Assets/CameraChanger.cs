using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    public move lastPlayer;
    public move nextPlayer;
    public Camera nextCamera;
    public Camera firstCamera;
    public Transform lastSpawn;
    public Transform nextSpawn;

    public void CameraChange(Transform lastPlayerTransform)
    {
        firstCamera.gameObject.SetActive(false);
        nextCamera.gameObject.SetActive(true);
        
        Camera aux = firstCamera;

        firstCamera = nextCamera;
        nextCamera = aux;

        lastPlayer = lastPlayerTransform.GetComponent<move>();

        nextPlayer.gameObject.SetActive(true);
        nextPlayer.transform.position = new Vector3(nextSpawn.position.x, lastPlayerTransform.position.y, nextSpawn.position.z);

        
        
        move auxplayer = nextPlayer;
        nextPlayer = lastPlayer;
        lastPlayer = auxplayer;



        


    }

}
