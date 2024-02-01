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
    Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        health = maxHealth;
        currenthealth = health;
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        rb.velocity = (new Vector2(rb.velocity.x, 2));
        if (health <= 0)
        {
            Respawn();
        }
        if (health < currenthealth)
        {
            currenthealth = health;
            anim.SetTrigger("hurt");
        }
    }
    void Respawn()
    {
        transform.position = startPos;
        health = maxHealth;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn"))
        {
            Respawn();
        }
    }
}
