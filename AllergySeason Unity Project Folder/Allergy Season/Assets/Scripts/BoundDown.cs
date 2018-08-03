using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundDown : MonoBehaviour {

    private bool isP1Fall;
    private bool isP2Fall;

    public GameObject player1Prefab;
    public GameObject player2Prefab;

    public float reviveTimeP1 = 5;
    public float reviveTimeP2 = 5;

    private void FixedUpdate()
    {
        if (isP1Fall)
        {
            if (reviveTimeP1 >= 0.1)
            {
                reviveTimeP1 -= Time.fixedDeltaTime;
            }
            else if (reviveTimeP1 < 0.1)
            {
                Instantiate(player1Prefab, new Vector3(-4, 0, 0), Quaternion.identity);
                isP1Fall = false;
                reviveTimeP1 = 5;
            }
            
        }
        if (isP2Fall)
        {
            if (reviveTimeP2 >= 0.1)
            {
                reviveTimeP2 -= Time.fixedDeltaTime;
            }
            else if (reviveTimeP2 < 0.1)
            {
                Instantiate(player2Prefab, new Vector3(4, 0, 0), Quaternion.identity);
                isP2Fall = false;
                reviveTimeP2 = 5;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player1")
        {
            collision.SendMessage("Die");
            isP1Fall = true;

        }
        else if (collision.tag == "Player2")
        {
            collision.SendMessage("Die");
            isP2Fall = true;
        }
    }
}
