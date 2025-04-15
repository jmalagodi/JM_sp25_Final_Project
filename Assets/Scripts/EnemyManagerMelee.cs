using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pointA;
    public GameObject pointB;
    public GameObject player;
    
    public Rigidbody rb;
    private Transform currentPoint;
    public float speed = 2.5f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentPoint = pointB.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            
        speed = 2.5f;


        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }   
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointA.transform)
        {    
            currentPoint = pointB.transform;
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        } 
    }
}
