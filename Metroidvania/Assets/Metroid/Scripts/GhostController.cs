using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostController : MonoBehaviour
{
    private bool isInvincible = false;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void ActivateInvincibility(float duration)
    {
        spriteRenderer.color = Color.red;
        isInvincible = true;
        StartCoroutine(InvincibilityDuration(duration));
    }

    private IEnumerator InvincibilityDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        isInvincible = false;
        spriteRenderer.color = Color.white;

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Arrow") && !isInvincible)
        {
            Debug.Log("TAK");
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}