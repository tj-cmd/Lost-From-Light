using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpUp;
    public bool IsGrounded = false;
    


    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }



    public void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.name == "RedHood")
        {
            IsGrounded = true;
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(Input.GetKeyDown("space") && (IsGrounded = true) )
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpUp));
        }


    }

   

}