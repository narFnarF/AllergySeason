using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1AnimationControll : MonoBehaviour {

    Animator Player1Animator;
    public KeyCode LeftMove;
    public KeyCode RightMove;
    public KeyCode Sneeze;

	// Use this for initialization
	void Start () {
        Player1Animator = GetComponent<Animator>();
        Player1Animator.SetBool("Player1Move", false);
        Player1Animator.SetBool("Player1Sneeze", false);

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(LeftMove) || Input.GetKey(RightMove))
        {
            Player1Animator.SetBool("Player1Move", true);
        }
        else
        {
            Player1Animator.SetBool("Player1Move", false);
        }

        if (Input.GetKey(Sneeze))
        {
            Player1Animator.SetBool("Player1Sneeze", true);
        }
        else
        {
            Player1Animator.SetBool("Player1Sneeze", false);
        }
	}
}
