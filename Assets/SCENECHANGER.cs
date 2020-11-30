using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCENECHANGER : MonoBehaviour
{
    public GameObject canvas;
    private void Start()
    {
        StartCoroutine(ChangeSceneCoroutine());
    }


    public IEnumerator ChangeSceneCoroutine()
    {
        yield return new WaitForSeconds(2f);
        canvas.SetActive(false);
        SceneManager.LoadScene(1);
    }
}
