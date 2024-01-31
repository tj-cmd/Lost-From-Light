using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    public int damage;
    public PlayerHealth playerHealth;

    public GameObject player;
    public float Speed;

    private float distance;
    public GameObject monsterAttackPoint;
    public float mRadius;
    public LayerMask player_Layer;

    private float dirX;
    private Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }
    //update called once per frame
    void Update()
    {

        //distance between monster and player
        distance = Vector2.Distance(transform.position, player.transform.position);
        if(distance < 2)
        {
            ani.SetBool("mAttack", true);
        }



        //AI for Monster Chase
        if (distance < 4 && distance > 1)
        {
            Vector2 direction = player.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, Speed * Time.deltaTime);
            ani.SetBool("Run", true);
        }else
        {
            ani.SetBool("Run", false);
        }
    }
    //Player Takes damage on collision
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }

    private void Attack()
    {
        Collider2D[] playerCollider = Physics2D.OverlapCircleAll(monsterAttackPoint.transform.position, mRadius, player_Layer);
        foreach (Collider2D enemyGameObject in playerCollider)
        {
            
            playerHealth.TakeDamage(damage);
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(monsterAttackPoint.transform.position, mRadius);
    }

    private void endAttack()
    {
        ani.SetBool("mAttack", false);
    }
    private void monsterDead()
    {
        Destroy(gameObject);
    }
}