using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TissueP2 : MonoBehaviour {

    public float force;

    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Kicked()
    {
        rb.AddForce(new Vector2(-force, force));
    }

    private void KickedByOpponent()
    {
        rb.AddForce(new Vector2(force, force));
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
