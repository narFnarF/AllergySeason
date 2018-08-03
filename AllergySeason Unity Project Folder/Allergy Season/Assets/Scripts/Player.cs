using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private int h;
    private Rigidbody2D rb;
    private bool isJumped;
    private bool isStunnedP1;
    private bool isStunnedP2;

    public float stunnedTimeP1=3;
    public float stunnedTimeP2 = 3;
    public float speed;
    public float thrust;
    public bool isPlayer1;
    public GameObject tissuePlayer1Prefab;
    public GameObject tissuePlayer2Prefab;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (isPlayer1)
        {
            if (isStunnedP1)
            {
                if (stunnedTimeP1 > 0.1)
                {
                    stunnedTimeP1 -= Time.fixedDeltaTime;
                }
                else if (stunnedTimeP1 <= 0.1)
                {
                    isStunnedP1 = false;
                    stunnedTimeP1 = 3;
                }
            }
            else
            {
                Move();
                Jump();
                Kick();
            }
        }
        else
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
        
    }

    private void Move()
    {
        transform.eulerAngles =new Vector3(0,0,0);
        if (isPlayer1)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
            }
        }
    }

    private void Jump()
    {
        if (!isJumped)
        {
            if (isPlayer1)
            {
                if (Input.GetKeyDown(KeyCode.W)&& PlayerManagement.Instance.Player1Power>=10)
                {
                    rb.AddForce(new Vector2(0, thrust));
                    Instantiate(tissuePlayer1Prefab, transform.position+new Vector3(0,-0.15f), Quaternion.identity);
                    PlayerManagement.Instance.Player1Power -= 10;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.UpArrow)&& PlayerManagement.Instance.Player2Power>=10)
                {
                    rb.AddForce(new Vector2(0, thrust));
                    Instantiate(tissuePlayer2Prefab, transform.position, Quaternion.identity);
                    PlayerManagement.Instance.Player2Power -= 10;
                }
            }
        }
    }

    private void Kick()
    {
        if (isPlayer1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0.3f, -0.15f), Vector2.right,0.8f);
                if (hit.collider.tag == "Tissue1")
                {
                    hit.collider.SendMessage("Kicked");
                }
                else if (hit.collider.tag == "Tissue2")
                {
                    hit.collider.SendMessage("KickedByOpponent");
                }
            }
        }
        if (!isPlayer1)
        {
            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(-0.3f, -0.15f), Vector2.left,0.8f);
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
        if (isPlayer1)
        {
            if (collision.collider.tag == "Tissue2")
            {
                isStunnedP1 = true;
            }
        }
        if (!isPlayer1)
        {
            if (collision.collider.tag == "Tissue1")
            {
                isStunnedP2 = true;
            }
        }
    }
}
