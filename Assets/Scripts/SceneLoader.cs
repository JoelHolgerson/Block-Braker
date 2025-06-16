using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

  public void ChangeScene(int buildindex)
  {
        SceneManager.LoadScene(buildindex);
  }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}

