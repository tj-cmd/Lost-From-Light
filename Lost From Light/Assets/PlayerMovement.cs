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
    //player attack variables
    public GameObject attackPoint;
    public float radius;
    public LayerMask enemies;
    public float damage = 10;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashTime = 0.2f;
    private float dashCool = 1f;
    [SerializeField] private TrailRenderer tr;
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
        if (isDashing)
        {
            return;
        }
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

        if (rb.velocity.y  > .1f)
        {
            state = MovementState.jumping;
        }
        //attacking
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("attack", true);
            
            
        }
        
        if(dirX > .1f || dirX < -.1f)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        anim.SetInteger("state", (int)state);

        if (Input.GetKeyDown(KeyCode.E) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    public void attack()
    {
        
    Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);
        foreach (Collider2D enemyGameobject in enemy)
        {
            Debug.Log("Hit enemy");
            enemyGameobject.GetComponent<Monster_Health>().health -= damage;
        }
    }

    public void endAttack()
    {
        anim.SetBool("attack", false);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGrav = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        rb.gravityScale = originalGrav;
        isDashing = false;
        yield return new WaitForSeconds(dashCool);
        canDash = true;
    }

}

