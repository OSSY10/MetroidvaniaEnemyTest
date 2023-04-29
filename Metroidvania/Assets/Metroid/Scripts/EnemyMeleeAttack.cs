using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    Color originalColor;
    [SerializeField] SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        originalColor = sprite.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ResetColor()
    {
        sprite.color = originalColor;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyWeapon"))
        {
            Debug.Log("hey");
            sprite.color = Color.red;
            Invoke("ResetColor", 0.4f);
        }
    }


}
