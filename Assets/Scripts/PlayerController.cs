using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
    
{
    // Start is called before the first frame update
    public float horizontalInput;
    public float speed = 10;
    public Rigidbody rb;
    public float jumpForce;
    public bool isOnGround;
    public bool attacking;
    public bool attackWait;
    public bool touchDown;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        attacking = false;
        attackWait = false;
        touchDown = false;
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;

        }
        if (!attackWait && touchDown && !isOnGround)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {

                touchDown = false;
                StartCoroutine(attack(10f));

            }
        }
        if (!attackWait && touchDown && isOnGround)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {

                StartCoroutine(attack(10f));

            }
        }
        if (horizontalInput != 0)
        {
            if (horizontalInput > 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
    }
    IEnumerator attackDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        attackWait = false;
    }
    IEnumerator attack(float force)
    {
        attacking = true;
        attackWait = true;
        if (horizontalInput > 0)
        {
            rb.AddForce(Vector3.right * force, ForceMode.Impulse);
        }
        if (horizontalInput < 0)
        {
            rb.AddForce(Vector3.right * -force, ForceMode.Impulse);
        }
        StartCoroutine(attackDelay(0.5f));
        yield return new WaitForSeconds(0.3f);
        attacking = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            touchDown = true;

        }
        if (collision.gameObject.CompareTag("Enemy") && !attacking)
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Enemy") && attacking)
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile") && attacking)
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Projectile") && !attacking)
        {
            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("KillBox"))
        {
            gameObject.SetActive(false);
        }
    }

}
