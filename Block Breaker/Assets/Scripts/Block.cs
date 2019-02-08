using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config params
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject particleSparkleVFX;
    [SerializeField] Sprite[] hitSprites;

    //reference
    Level level;
    GameStatus gameStatus;
    SpriteRenderer spriteRenderer;

    //stats
    private int timeHits;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameStatus = FindObjectOfType<GameStatus>();
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            PlayAudioSFX();
            gameStatus.AddToScore();
            timeHits++;
            int maxHits = hitSprites.Length + 1;
            if (timeHits >= maxHits)
            {
                DestroyBlock();
            }
            else
            {
                ShowNextSprite();
            }
        }
    }

    private void ShowNextSprite()
    {
        int currentHitSprite = timeHits - 1;
        if (hitSprites[currentHitSprite] != null)
        {
            spriteRenderer.sprite = hitSprites[currentHitSprite];
        }
        else
        {
            Debug.LogError(gameObject.name + "don't have sprite for current damage");
        }
    }

    private void DestroyBlock()
    {
        TriggerSparklesVFX();
        level.BlockDestroyed();
        Destroy(gameObject);
    }

    private void PlayAudioSFX()
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX ()
    {
        GameObject sparkle = Instantiate(particleSparkleVFX, transform.position, transform.rotation);
        Destroy(sparkle, 1f);
    }
}
