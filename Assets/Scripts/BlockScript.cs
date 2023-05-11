using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [SerializeField] AudioClip onDestruction;
    LevelScript level;
    GameStats block;
    [SerializeField] GameObject specialEffects;
     int currentHits;
    [SerializeField] Sprite[] damageSprite;

    private void Start()
    {
        level = FindObjectOfType<LevelScript>();
        if (tag == "Breakable") 
        { 
            level.CountNumberofBlocks(); 
        }
        block = FindObjectOfType<GameStats>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            currentHits++;
            int maxhits = damageSprite.Length + 1;
            if (currentHits >= maxhits)
            {
                breakBlock();
            }
            else
            {
                int spriteIndex = currentHits - 1;
                GetComponent<SpriteRenderer>().sprite = damageSprite[spriteIndex];
            }
        }
        AudioSource.PlayClipAtPoint(onDestruction, Camera.main.transform.position);  
    }

    private void breakBlock()
    {
        Destroy(gameObject);
        block.AddScore();
        VFX();
        level.Destroyed();
    }

    private void VFX()
    {
        GameObject sparkles = Instantiate(specialEffects, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
