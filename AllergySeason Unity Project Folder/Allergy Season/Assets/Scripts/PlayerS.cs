using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerS : MonoBehaviour
{

    private int h;
    private Rigidbody2D rb;
    private bool isJumped;
    private bool isStunned;

    public int nb;
    public float PlayerPower;
    public float stunnedTime = 3;
    public float speed;
    public float thrust;
    public float riseSpeed;
    public Vector2 kickDirection;
    public float kickForce;
    public GameObject tissuePlayerPrefab;
    public GameObject playerPrefab;

    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode jumpKey;
    public KeyCode kickKey;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerPower < 100)
        {
            PlayerPower += Time.fixedDeltaTime * riseSpeed;
        }
        if (isStunned)
        {
            if (stunnedTime > 0.1)
            {
                stunnedTime -= Time.fixedDeltaTime;
            }
            else if (stunnedTime <= 0.1)
            {
                isStunned = false;
                stunnedTime = 3;
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
        if (Input.GetKey(leftKey))
        {
            transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
        }
        else if (Input.GetKey(rightKey))
        {
            transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
        }
    }

    private void Jump()
    {
        if (!isJumped)
        {
            if (Input.GetKeyDown(jumpKey) && PlayerPower >= 10)
            {
                rb.AddForce(new Vector2(0, thrust));
                Instantiate(tissuePlayerPrefab, transform.position + new Vector3(0, -0.15f), Quaternion.identity);
                PlayerPower -= 10;
            }
        }
    }

    private void Kick()
    {
        if (Input.GetKeyDown(kickKey))
        {
            var sign = Mathf.Sign(kickDirection.x);
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0.3f*sign, -0.15f), kickDirection, 0.8f);
            if (hit.collider.CompareTag("Tissue1") || hit.collider.CompareTag("Tissue2"))
            {
                hit.rigidbody.AddForce((kickDirection + new Vector2(0, 1f)) * kickForce, ForceMode2D.Impulse);
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
        if (collision.collider.tag == "Tissue2")
         {
            isStunned = true;
            collision.collider.SendMessage("Die");
         }   
    }

    private void Die()
    {
        Destroy(gameObject);
        Invoke("Born", 5);
    }

    private void Born()
    {
        Instantiate(playerPrefab, new Vector3(-4, 0, 0), Quaternion.identity);
    }

    private void Boost()
    {
        riseSpeed += 1;
    }

    private void Resume()
    {
        riseSpeed -= 1;
    }
}

