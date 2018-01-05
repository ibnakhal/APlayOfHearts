using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Movement : MonoBehaviour {
    [Header("Sprites")]
    public SpriteRenderer masterSprite;
    public Sprite s_still;
    public Sprite s_walk;
    public Sprite s_run;
    public Sprite s_jump;
    public Sprite s_fetal;
    public bool facingRight = true;
    public bool fetal=false;
    [Header("Movement")]
    public float speed;
    public float runSpeed;
    private Rigidbody2D body;


    [Header("Jumping")]
    public float jumpSpeed;
    public bool grounded;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    private Vector2 velocity = Vector2.zero;

    [Header("Interaction")]
    public bool talking;

	// Use this for initialization
	void Start () {
        masterSprite = this.GetComponent<SpriteRenderer>();
        body = this.GetComponent<Rigidbody2D>();

    }



    // Update is called once per frame
    void Update()
    {
        //    Debug.Log(this.GetComponent<Rigidbody2D>().velocity);

        if (Input.GetAxis("Jump")>0)
        {
            if (grounded)
            {
                masterSprite.sprite = s_jump;
                body.AddForce(new Vector2(0, jumpSpeed));
            }
        }
        if (!Input.anyKey && grounded)
        {
            masterSprite.sprite = s_still;
        }
        if (!grounded && !fetal)
        {
            masterSprite.sprite = s_jump;
        }
        //if (this.GetComponent<Rigidbody2D>().velocity.y != 0)
        //{
        //    grounded = true;
        //    masterSprite.sprite = s_jump;
        //}
        //else
        //{
        //    grounded = false;
        //}
    }




    public void LateUpdate()
    {
        //if (!jumped)
        //{
        //    body.velocity = velocity;
        //}
    }

    public void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);



        float move = Input.GetAxis("Horizontal");
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            body.velocity = new Vector2(move * speed, body.velocity.y);
            masterSprite.sprite = s_walk;
        }
        else
        {
            body.velocity = new Vector2(move * runSpeed, body.velocity.y);
            masterSprite.sprite = s_run;
        }
        if (move>0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }

    public void Flip()
    {
        facingRight = !facingRight;
        if(facingRight)
        {
            masterSprite.flipX = true;
        }
        else if (!facingRight)
        {
            masterSprite.flipX = false;
        }
    }
}
