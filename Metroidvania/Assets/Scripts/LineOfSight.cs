using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    public float visionDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Raycast();
    }
    void Raycast()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, visionDistance);
        if(hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * visionDistance, Color.green);
        }
    }
}
