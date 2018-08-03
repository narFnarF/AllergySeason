using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour {

    private int h;
    private Rigidbody2D rb;
    private bool isJumped;
    private bool isStunnedP2;

    public float stunnedTimeP2 = 3;
    public float speed;
    public float thrust;
    public GameObject tissuePlayer2Prefab;
    public GameObject player2Prefab;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isStunnedP2)
        {
            if (stunnedTimeP2 > 0.1)
            {
                stunnedTimeP2 -= Time.fixedDeltaTime;
            }
            else if (stunnedTimeP2 <= 0.1)
            {
                isStunnedP2 = false;
                stunnedTimeP2 = 3;
            }
        }
        else
        {
            Move();
            Jump();
            Kick();
        }
    }

    private void Move()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
        }
    }

    private void Jump()
    {
        if (!isJumped)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && PlayerManagement.Instance.Player2Power >= 10)
            {
                rb.AddForce(new Vector2(0, thrust));
                Instantiate(tissuePlayer2Prefab, transform.position, Quaternion.identity);
                PlayerManagement.Instance.Player2Power -= 10;
            }
        }
    }

    private void Kick()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(-0.3f, -0.15f), Vector2.left, 0.8f);
            if (hit.collider.tag == "Tissue2")
            {
                hit.collider.SendMessage("Kicked");
            }
            else if (hit.collider.tag == "Tissue1")
            {
                hit.collider.SendMessage("KickedByOpponent");
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isJumped = false;
        }
        else
        {
            isJumped = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Tissue1")
        {
            isStunnedP2 = true;
            collision.collider.SendMessage("Die");
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
    
}
