using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEditor;
using UnityEngine;

public class EnemyAggroRangedS : MonoBehaviour
{
    // Start is called before the first frame update
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
        patrol = true;
        spawnTimer = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 directionToPlayer = player.transform.position - transform.position;


        float angleToPlayer = Vector3.Angle(transform.right, directionToPlayer);
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);


        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        bool playerInSight = angleToPlayer < fieldOfViewAngle / 2f;
      
            
            
        spawnTimer += Time.deltaTime;


            if (spawnTimer >= spawnCooldown) 
            {
                if (distanceToPlayer < aggroRange) 
                {
                    SpawnProjectiles(player.transform.position);
                    spawnTimer = 0f;
                }
                
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
    public void SpawnProjectiles(Vector3 targetPosition)
    {

        GameObject newProjectile = Instantiate(projectile, projectileSpawner.transform.position, projectileSpawner.transform.rotation);
        newProjectile.GetComponent<ProjectileMove>().SetTargetPosition(targetPosition);

    }
}
