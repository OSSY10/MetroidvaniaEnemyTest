using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius = 5f;
    [Range(1, 360)] public float angle = 45f;
    public LayerMask targetLayer;
    public LayerMask obstructionLayer;
    public float boolTime = 0;
    FollowAI followAI;


    public GameObject playerRef;

    public bool canSeePlayer;
    // Start is called before the first frame update
    void Start()
    {
        canSeePlayer = false;
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVCheck());
        followAI = GetComponent<FollowAI>();
    }

    private IEnumerator FOVCheck()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        while (true)
        {
            yield return wait;
            FOV();
        }
    }
    private void FOV()
    {
        if (playerRef != null)
        {
            Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);
            if (rangeCheck.Length > 0)
            {
                Transform target = rangeCheck[0].transform;
                Vector2 directionToTarget = (target.position - transform.position).normalized;
                if (transform.localScale.x == 1)
                {
                    if (Vector2.Angle(transform.right, directionToTarget) < angle / 2)
                    {
                        float distanceToTarget = Vector2.Distance(transform.position, target.position);
                        if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionLayer))
                        {
                            canSeePlayer = true;
                        }
                        else if (Mathf.Abs(transform.position.x - target.position.x) > followAI.minimumDistance)
                        {
                            canSeePlayer = false;
                            
                        }
                        
                    }
                    else if (Mathf.Abs(transform.position.x - target.position.x) > followAI.minimumDistance)
                    {
                        canSeePlayer = false;
                    }
                }
                else if (transform.localScale.x == -1)
                {
                    if (Vector2.Angle(transform.right * -1, directionToTarget) < angle / 2)
                    {
                        float distanceToTarget = Vector2.Distance(transform.position, target.position);
                        if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionLayer))
                        {
                            canSeePlayer = true;
                        }
                        else if (Vector2.Distance(transform.position, target.position) > followAI.minimumDistance)
                        {
                            canSeePlayer = false;
                        }
                    }
                }


            }
            else if (Vector2.Distance(transform.position, playerRef.transform.position) > followAI.minimumDistance)
            {
                canSeePlayer = false;
            }
        }
        
    }
  
}

  
