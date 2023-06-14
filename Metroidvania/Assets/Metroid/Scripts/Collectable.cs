using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private float invincibilityDuration = 5f;
    [SerializeField] private GhostController ghost;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            if (ghost != null)
            {
                ghost.ActivateInvincibility(invincibilityDuration);
            }
            Destroy(gameObject);
        }
    }
}