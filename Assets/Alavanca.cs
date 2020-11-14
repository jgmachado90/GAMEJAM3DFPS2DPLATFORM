using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alavanca : MonoBehaviour
{
    public List<GameObject> alavancaActivatorObjects;
    public bool activated = false;

    public void Activate()
    {
      
        foreach(GameObject gO in alavancaActivatorObjects)
        {
            if (gO.GetComponent<Door>().canAct)
            {
                GetComponent<Animator>().SetBool("Activated", true);
                activated = true;
                gO.GetComponent<Door>().Action();
            }
        }
    }


    public void Deactivate()
    {
       
        foreach (GameObject gO in alavancaActivatorObjects)
        {
            if (gO.GetComponent<Door>().canAct)
            {
                GetComponent<Animator>().SetBool("Activated", false);
                activated = false;
                gO.GetComponent<Door>().Action();
            }
        }
    }
}
