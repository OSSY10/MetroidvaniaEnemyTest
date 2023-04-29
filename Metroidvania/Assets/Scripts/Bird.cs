using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float launchForce;
    [SerializeField] float maxDragDistance = 3f;
    Vector2 startPosition;
    Rigidbody2D rb;
    SpriteRenderer sr;
    private PlayerController playerController;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        playerController = FindObjectOfType<PlayerController>();
    }
    void Start()
    {
        startPosition = rb.position;
        rb.isKinematic = true;
    }
    
    

    void OnMouseDown()
    {
        sr.color = Color.red;
    }
    void OnMouseUp()
    {
        Vector2 currentPosition = rb.position;
        Vector2 direction = startPosition - currentPosition;
        direction.Normalize();
        rb.isKinematic = false;
        rb.AddForce(direction * launchForce);
        sr.color = Color.white;
        
    }
    void OnMouseDrag()
    {
        if (playerController.holdingCube)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 desiredPosition = mousePosition;
  
            float distance = Vector2.Distance(desiredPosition, startPosition);
            if (distance > maxDragDistance)
            {
                Vector2 direction = desiredPosition - startPosition;
                direction.Normalize();
                desiredPosition = startPosition + (direction * maxDragDistance);

            }
            if (desiredPosition.x > startPosition.x)
                desiredPosition.x = startPosition.x;
  

            rb.position = desiredPosition;
        }
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelay());
    }
    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        rb.position = startPosition;
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
