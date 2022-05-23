using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public Transform target;
    public float distanceLimit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool Detection()
    {
        if(Vector2.Distance(transform.position, target.position) < distanceLimit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
