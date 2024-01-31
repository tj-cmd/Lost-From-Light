using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    public int maxHealth = 10;
    public int health;
    private Rigidbody2D rb;
    public float currenthealth;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        health = maxHealth;
        currenthealth = health;
        rb = GetComponent<Rigidbody2D>();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        rb.velocity = (new Vector2(rb.velocity.x, 2));
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (health < currenthealth)
        {
            currenthealth = health;
            anim.SetTrigger("hurt");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
