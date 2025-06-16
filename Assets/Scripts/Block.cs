using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] Sprite[] blockStages;

    [SerializeField] int scoreToAddOnHit = 10;
    [SerializeField] int scoreToAddOnDestruction = 100;

    [SerializeField] GameObject hitEffect;

    int numberOfHits = 0;

    SpriteRenderer spriteRenderer;
    LevelController levelController;
    ScoreManager scoreManager;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        levelController = FindObjectOfType<LevelController>();
        scoreManager = FindObjectOfType<ScoreManager>();

        levelController.AddBlock();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(hitEffect, transform.position, Quaternion.identity);

        numberOfHits++;

        if (numberOfHits >= blockStages.Length)
        {
            levelController.RemoveBlock();
            scoreManager.AddScore(scoreToAddOnDestruction);
            Destroy(gameObject);
        }
        else
        {
            scoreManager.AddScore(scoreToAddOnHit);
            spriteRenderer.sprite = blockStages[numberOfHits];
        }

        if (numberOfHits == 1)
        {
            spriteRenderer.color = Color.yellow;
            Changesize();
        }
        else if (numberOfHits == 2)
        {
            spriteRenderer.color = Color.red;
            Changesize();
        }
    }

    void Changesize()
    {
       transform.localScale = new Vector2(transform.localScale.y -0.1f, transform.localScale.x -0.1f);
    }
}
