using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player;
    public Vector2 pos;
    void Start()
    {
        transform.position = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos = new Vector2 (Player.position.x, pos.y);
        transform.position = pos;
    }
}
