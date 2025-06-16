using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseScript : MonoBehaviour
{
    [SerializeField] SceneLoader SceneLoader;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<ScoreManager>().ResetScore();

        SceneLoader.ReloadScene();
    }
}
