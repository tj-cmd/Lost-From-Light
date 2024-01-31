using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Health : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 20;
    public float currenthealth;
    private Animator ani;
    
    void Start()
    {
        ani = GetComponent<Animator>();
        currenthealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health < currenthealth)
        {
            currenthealth = health;
            ani.SetTrigger("gotHit");
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
