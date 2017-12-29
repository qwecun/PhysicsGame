using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {

    private Rigidbody2D rb2d;
    private bool facingRight = true;
    private bool isGround = true;
    private Animator anim;

    // Use this for initialization
    void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Flip();
    }
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        if (h < 0 && !facingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (h > 0 && facingRight)
        {
            // ... flip the player.
            Flip();
        }

        if (h > 0)
        {
            //rb2d.AddForce(Vector2.right *4);
            rb2d.velocity = new Vector2(5, rb2d.velocity.y);
        }
        else if (h < 0)
        {
            // rb2d.AddForce(Vector2.right *-4);
            rb2d.velocity = new Vector2(-5, rb2d.velocity.y);
        }

        if (Input.GetKey(KeyCode.Space) && isGround)
        {

            rb2d.velocity = new Vector2(rb2d.velocity.x, 5);
            isGround = false;
        }
        anim.SetBool("isGround", isGround);
        if (rb2d.velocity.x > 0.1 || rb2d.velocity.x < -0.1)
            anim.SetInteger("speed", 1);
        else
            anim.SetInteger("speed", 0);
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "ground")
            isGround = true;
    }
}
