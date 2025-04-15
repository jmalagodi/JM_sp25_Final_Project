using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEditor;
using UnityEngine;

public class EnemyAggroRanged : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pointA;
    public GameObject pointB;
    public GameObject player;
    public GameObject projectile;
    public GameObject projectileSpawner;
    public Rigidbody rb;
    private Transform currentPoint;
    public float speed;
    public bool patrol;
    public float aggroRange;
    public float fieldOfViewAngle = 60f;
    public Vector3 lookDirection2;
    private float spawnCooldown = 2f;
    private float spawnTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentPoint = pointB.transform;
        patrol = true;
        spawnTimer = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        Vector2 directionToPlayer = player.transform.position - transform.position;


        float angleToPlayer = Vector3.Angle(transform.right, directionToPlayer);
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);


        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        bool playerInSight = angleToPlayer < fieldOfViewAngle / 2f;
      

        //Debug.Log((Vector2.Distance(transform.position, player.transform.position)));
        if (Vector2.Distance(transform.position, player.transform.position) < aggroRange)
        {
            patrol = false;
        }

        if (patrol)
        {
            speed = 1.5f;
            spawnTimer = 2f;
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

                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                currentPoint = pointA.transform;
              
            }
            if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointA.transform)
            {

                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                currentPoint = pointB.transform;
                
            }
        }
        else 
        {
            speed = 0f;
            
            transform.Translate(lookDirection * -speed * Time.deltaTime);
            
            spawnTimer += Time.deltaTime;


            if (spawnTimer >= spawnCooldown) 
            {
                
                SpawnProjectiles(player.transform.position);
                spawnTimer = 0f;
                
                
            }
            if (Vector2.Distance(transform.position, player.transform.position) > aggroRange)
            {
                patrol = true;
            }
            if (lookDirection.x > 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else if (lookDirection.x < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }

        }
       
    }
    public void SpawnProjectiles(Vector3 targetPosition)
    {

        GameObject newProjectile = Instantiate(projectile, projectileSpawner.transform.position, projectileSpawner.transform.rotation);
        newProjectile.GetComponent<ProjectileMove>().SetTargetPosition(targetPosition);

    }
}
