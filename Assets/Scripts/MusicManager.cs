using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private void Awake()
    {
        int numberOfSoundtracks = FindObjectsOfType<AudioSource>().Length;

        if (numberOfSoundtracks > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }
}
