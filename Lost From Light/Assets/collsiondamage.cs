using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collsiondamage : MonoBehaviour
{
    public int damage = 100;
    public PlayerHealth playerHealth;

    public GameObject player;
    public float Speed;

    private float distance;
    public GameObject monsterAttackPoint;
    public float mRadius;
    public LayerMask player_Layer;

    private float dirX;


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
