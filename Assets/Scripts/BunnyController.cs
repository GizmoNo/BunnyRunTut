using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyController : MonoBehaviour {

    private Rigidbody2D MyRigidBody;
    public float BunnyJumpForce = 750f;
	// Use this for initialization
	void Start () {

        MyRigidBody = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonUp("Jump"))
        {

            MyRigidBody.AddForce(transform.up * BunnyJumpForce);
        }
	}
}
