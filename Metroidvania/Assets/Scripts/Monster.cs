using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    bool hasDie;
    [SerializeField] Sprite deathSprite;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(ShouldDieFromCollision(collision))
        {
           StartCoroutine(Die());
        }
    }

    bool ShouldDieFromCollision(Collision2D collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();
        if(hasDie)
        {
            return false;
        }
        if(bird != null)
        {
            return true;
        }
        if (collision.contacts[0].normal.y < -0.5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    IEnumerator Die()
    {
        hasDie = true; 
        GetComponent<SpriteRenderer>().sprite = deathSprite;
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
