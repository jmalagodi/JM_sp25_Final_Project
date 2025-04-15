using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player;
    public Vector3 desiredPos;
    public Vector3 pos;
    public float smoothTime = 0.5f;
    private Vector3 velocity = Vector3.zero;
    public float camDistance = -30.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pos = transform.position;
  
        Vector3 smoothX = Vector3.SmoothDamp(pos, desiredPos, ref velocity, smoothTime, Mathf.Infinity);
        transform.position = smoothX;
        
        if (Input.GetKey(KeyCode.W)) 
        {
            Debug.Log("W");
            desiredPos = new Vector3(Player.position.x, Player.position.y + 5, camDistance);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            desiredPos = new Vector3(Player.position.x, Player.position.y - 5, camDistance);
        }
        else
        {
            desiredPos = new Vector3(Player.position.x, Player.position.y, camDistance);
        }

    }
}
