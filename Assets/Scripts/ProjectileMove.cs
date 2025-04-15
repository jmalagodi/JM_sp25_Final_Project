using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileMove : MonoBehaviour
{
    public float speed;
    private Vector3 moveDirection;
    public void SetTargetPosition(Vector3 target)
    {
        moveDirection = (target - transform.position).normalized;
        StartCoroutine(despawnTimer(15));
    }
    IEnumerator despawnTimer(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }
   
}