using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] AudioClip paddleSound;
    [SerializeField] AudioClip blockSound;
    [SerializeField] AudioClip wallSound;

    AudioSource audioSource;
    Rigidbody2D myRigidbody;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void PlaySound(AudioClip soundToPlay)
    {
        audioSource.clip = soundToPlay;
        audioSource.Play();
    }
    


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            PlaySound(blockSound);

            FindObjectOfType<ScreenShaker>().TriggerShake(0.1f);
        }
        else if (other.gameObject.CompareTag("Paddle"))
        {
            PlaySound(paddleSound);

            FindObjectOfType<ScreenShaker>().TriggerShake(0.5f);
        }
        else if (other.gameObject.CompareTag("Wall"))
        {
            PlaySound(wallSound);

            FindObjectOfType<ScreenShaker>().TriggerShake(0.1f);
        }
    }

    // 90-Degree Blocker
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (myRigidbody.velocity.x > -1 && myRigidbody.velocity.x < 1)
        {
            myRigidbody.velocity = new Vector2(2f, myRigidbody.velocity.y);
        }
        else if (myRigidbody.velocity.y > -1 && myRigidbody.velocity.y < 1)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 2f);
        }

    }
}
