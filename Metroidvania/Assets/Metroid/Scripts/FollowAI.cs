using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAI : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float shotSpeed;
    [SerializeField] public float minimumDistance;
    [SerializeField] Transform target;
    [SerializeField] float timeBetweenShot;
    PatrolAI patrolAI;
    FieldOfView FOV;
    Animator anim;
    Rigidbody2D rb;
    public GameObject arrowClone;
    public bool canAttack;
    bool spawned = false;
    bool canMove = true;
    [SerializeField] ArrowController arrowController;
    [SerializeField] private Transform arrowPosition;

    // Start is called before the first frame update
    void Start()
    {
        FOV = GetComponent<FieldOfView>();
        patrolAI = GetComponent<PatrolAI>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Animation();
        FollowOrAttack();
    }

    void FollowOrAttack()
    {
        if (target != null)
        {
            
            if (FOV.canSeePlayer)
            {

                TurnAround();

                if (Vector2.Distance(transform.position, target.position) > minimumDistance)
                {
                    canAttack = false;
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);
                    patrolAI.walking = true;
                }
                else if(Vector2.Distance(transform.position, target.position) < minimumDistance)
                {              
                    patrolAI.walking = false;
                    canAttack = true;
                    if (this.gameObject.CompareTag("Archer") && !spawned)
                    {
                        StartCoroutine(Shoot());

                    }
                    
                }
            }
        }
        else
        {
            canAttack = false;
        }
    }
    void Animation()
    {
        anim.SetBool("canAttack", canAttack);
    }
    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
    public IEnumerator Shoot()
    {
        
        spawned = true;
        yield return new WaitForSeconds(timeBetweenShot);
        GameObject newArrow = Instantiate(arrowClone, arrowPosition.position, Quaternion.identity);
        newArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(shotSpeed * transform.localScale.x * Time.fixedDeltaTime, 0f);
        spawned = false;
        


    }
    void TurnAround()
    {
        if (transform.position.x > target.position.x)
        {
            
            transform.localScale = new Vector2(-1, 1);
        }
        else if(transform.position.x < target.position.x)
        {
            
            transform.localScale = new Vector2(1, 1);
        }
    }
}
