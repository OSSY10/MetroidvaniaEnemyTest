using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float waitTime;
    [SerializeField] Transform[] patrolPoints;
    int currentPointIndex;
    bool once;
    public bool walking;
    Rigidbody2D rb;
    Animator anim;
    PlayerDetection playerDetection;
    FieldOfView FOV;
    FollowAI followAI;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerDetection = GetComponent<PlayerDetection>();
        FOV = GetComponent<FieldOfView>();
        followAI = GetComponent<FollowAI>();
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
        Animation();
        
    }
    void Patrol()
    {
        if (!FOV.canSeePlayer)
        {
            followAI.canAttack = false;
            if (Vector2.Distance(transform.position, patrolPoints[currentPointIndex].position) > 1f)
            {
                if (transform.position.x > patrolPoints[currentPointIndex].position.x)
                {
                    transform.localScale = new Vector2(-1, 1);
                }
                else
                {
                    transform.localScale = new Vector2(1, 1);
                }
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);
                walking = true;
            }
            else
            {
                if (once == false)
                {
                    once = true;
                    walking = false;
                    StartCoroutine(Wait());
                }
            }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        if (currentPointIndex + 1 < patrolPoints.Length)
        {
            
            currentPointIndex++;
        }
        else
        {
            
            currentPointIndex = 0;
        }
        once = false;
    }
    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
    void Animation()
    {
        anim.SetBool("walk", walking);
    }
   
}
