using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]    float playerSpeed = 10f;
    private Rigidbody2D rb;
    private BoxCollider2D col;
    public float jumpForce;
    [SerializeField] private LayerMask jumpGround;
    private Animator anim;

    private float dirX = 0f;
    private enum MovementState { idle, running, jumping }
    
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        col = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();


    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, jumpGround);
    }



    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (dirX * playerSpeed, rb.velocity.y);

      





        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = (new Vector2(rb.velocity.x, jumpForce));
        }

        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;

        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y  > 0f)
        {
            state = MovementState.jumping;
        }

        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("attack", Input.GetMouseButtonUp(0));
        }
        
        
            anim.SetBool("attack", false);
        
        
        
            
        


        anim.SetInteger("state", (int)state);
        
    }


}

