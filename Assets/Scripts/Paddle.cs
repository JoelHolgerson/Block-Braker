using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] Rigidbody2D BallRb;

    [SerializeField] float paddleMaxPosX = 7f;
    [SerializeField] float paddlePosY = -3f;
    [SerializeField] float ballOffsetY = 0.5f;

    [SerializeField] float ballStartingSpeed = 5f;
    [SerializeField] float ballDirectionSpanX = 10f;

    bool ballReleased = false;


    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float paddlePosX = Mathf.Clamp(mousePos.x, -paddleMaxPosX, paddleMaxPosX);

        transform.position = new Vector2(paddlePosX, paddlePosY);

        if (!ballReleased)
        {
            ReleaseBallOnClick();

           BallRb.position = new Vector2(paddlePosX, paddlePosY + ballOffsetY);
        }  
    }

    void ReleaseBallOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ballReleased = true;
            float ballStartingDirectionX = Random.Range(-ballDirectionSpanX, ballDirectionSpanX);
            BallRb.velocity = new Vector2(ballStartingDirectionX, 1f).normalized * ballStartingSpeed;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector2 ballPosition = new Vector2(transform.position.x, transform.position.y + ballOffsetY);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(ballPosition, ballPosition + new Vector2(-ballDirectionSpanX, 1).normalized);
        Gizmos.DrawLine(ballPosition, ballPosition + new Vector2(ballDirectionSpanX, 1).normalized);
    }
} 


            // if (ballReleased == false)
            // if (!ballReleased) :om inte ballReleased
            // ! :inte 
            // != :inte lika med
            // == :lika med

            // !Input :när inte intryckt
