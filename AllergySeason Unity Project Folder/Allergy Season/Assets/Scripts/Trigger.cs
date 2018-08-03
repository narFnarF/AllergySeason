using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

    public GameObject player1Prefab;
    public GameObject player2Prefab;

    public float reviveTimeP1 = 5;
    public float reviveTimeP2 = 5;

    private bool isP1Fall;

    private void FixedUpdate()
    {
        if (isP1Fall == true)
        {
            
            if (reviveTimeP1 > 0.1)
            {
                reviveTimeP1 -= Time.fixedDeltaTime;
            }
            else if (reviveTimeP1 <= 0.1)
            {
                Instantiate(player1Prefab, new Vector3(-4, 0, 0), Quaternion.identity);
                reviveTimeP1 = 5;
            }
            isP1Fall = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tissue1")
        {
            PlayerManagement.Instance.Player1Score++;
            PlayerManagement.Instance.TotalScore++;
        }
        else if (collision.tag == "Tissue2")
        {
            PlayerManagement.Instance.Player2Score++;
            PlayerManagement.Instance.TotalScore++;
        }
    }
}
