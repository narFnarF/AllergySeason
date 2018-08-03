using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour {

    private Rigidbody2D rb;
    private bool isJumped;
    public int h;
    public float moveTimeVal=2;

    public float speed;
    public float thrust;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        h = Random.Range(-1, 2);
        if (moveTimeVal <= 0.1)
        {
            rb.AddForce(new Vector2(h * thrust, thrust));
            h = Random.Range(-1, 2);
            moveTimeVal = 2;
        }
        else
        {
            moveTimeVal -= Time.fixedDeltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player1" || collision.tag == "Player2")
        {
            collision.SendMessage("Boost");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player1" || collision.tag == "Player2")
        {
            collision.SendMessage("Resume");
        }
    }
}
