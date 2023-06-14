using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowController : MonoBehaviour
{
    public float arrowSpeed;
    Rigidbody2D rb;
    public Vector2 arrowMoveDirection;
    [SerializeField] GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        // if (other.gameObject.CompareTag("Ghost"))
        // {
        //     Destroy(other.gameObject);
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // }

        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
