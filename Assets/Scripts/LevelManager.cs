using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject WIPimg;
    
    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void DisplayWIP()
    {
        WIPimg.SetActive(true);
        StartCoroutine(Timer(1f));
    }

    private IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
        WIPimg.SetActive(false);
    }
    
}
