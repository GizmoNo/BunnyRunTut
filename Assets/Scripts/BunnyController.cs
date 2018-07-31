using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BunnyController : MonoBehaviour {

    private Rigidbody2D MyRigidBody;
    public float BunnyJumpForce = 500f;
    private Animator myAnim;
    private float bunnyHurtTime = -1;
    private Collider2D myCollider;
    public Text scoreText;
    private float startTime;
    private int jumpsLeft = 2;



	// Use this for initialization
	void Start () {

        MyRigidBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();

        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (bunnyHurtTime == -1)
        {



            if (Input.GetButtonUp("Jump") && jumpsLeft > 0)
            {
                if (MyRigidBody.velocity.y < 0)
                {
                    MyRigidBody.velocity = Vector2.zero;
                }

                if (jumpsLeft == 1)
                {
                    MyRigidBody.AddForce(transform.up * BunnyJumpForce * 0.75f);
                }
                else
                {
                    MyRigidBody.AddForce(transform.up * BunnyJumpForce);
                }
                jumpsLeft--;
            }

            myAnim.SetFloat("vVelocity", MyRigidBody.velocity.y);
            scoreText.text = (Time.time - startTime).ToString("0.0");
        }
        else
        {
            if(Time.time > bunnyHurtTime + 2)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
            
        }

        //myAnim.SetFloat("vVelocity", Mathf.Abs(MyRigidBody.velocity.y));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {

            foreach (PrefabSpawner spawner in FindObjectsOfType<PrefabSpawner>())
            {
                spawner.enabled = false;
            }

            foreach (MoveLeft moveLefter in FindObjectsOfType<MoveLeft>())
            {
                moveLefter.enabled = false;
            }

            
            bunnyHurtTime = Time.time;
            myAnim.SetBool("BunnyHurt", true);
            MyRigidBody.velocity = Vector2.zero;
            MyRigidBody.AddForce(transform.up * BunnyJumpForce);
            myCollider.enabled = false;
        }
        else if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            jumpsLeft = 2;
        }
        
    }
}
