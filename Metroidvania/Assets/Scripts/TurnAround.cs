using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAround : MonoBehaviour
{
    FieldOfView FOV;
    [SerializeField] Transform target;
    // Start is called before the first frame update
    void Start()
    {
        FOV = FindObjectOfType<FieldOfView>();
    }

    // Update is called once per frame
    void Update()
    {
        if(FOV.canSeePlayer)
        {
            Turn();
        }
    }
    void Turn()
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
