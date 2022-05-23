using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;
    Rigidbody2D rb;
    public Vector2 moveDirection;
    [SerializeField] GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = moveDirection * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(impactEffect != null)
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
        }
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
