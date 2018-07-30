using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyController : MonoBehaviour {

    private Rigidbody2D MyRigidBody;
    public float BunnyJumpForce = 500f;
    private Animator myAnim;
	// Use this for initialization
	void Start () {

        MyRigidBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonUp("Jump"))
        {

            MyRigidBody.AddForce(transform.up * BunnyJumpForce);
        }

        myAnim.SetFloat("vVelocity", MyRigidBody.velocity.y);

        //myAnim.SetFloat("vVelocity", Mathf.Abs(MyRigidBody.velocity.y));
    }
}
