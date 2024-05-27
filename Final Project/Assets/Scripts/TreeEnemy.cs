using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeEnemy : Enemy
{
    private Vector3 movement = Vector3.zero;
    private Vector3 direction = Vector3.zero;
    private bool moving = false;
    private float timeBetweenAttacks = 1f;
    private float timePastAttack = 0f;
    [SerializeField] private int damage;



    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 2.5f) { 
            moving = true;
            Movement();
        }
        else if(moving) 
        {
            moving = false;
            animator.SetBool("Moving", false);
        }

    }

    public override void Movement()
    {
        base.Movement();
        direction = player.transform.position - transform.position;
        Vector3.Normalize(direction);
        if(Vector3.Distance(transform.position, player.transform.position) < 0.5f)
        {
            timePastAttack += Time.deltaTime;
            if(timePastAttack > timeBetweenAttacks)
            {
                player.GetComponent<PlayerHealth>().TakeDamage(damage);
                timePastAttack = 0f;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            if(timePastAttack != 0f)
            {
                timePastAttack = 0f;
            }
        }
        //direction = movement.normalized;
        //enemyRigidBody.MovePosition(movement);
        if(direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        animator.SetFloat("MoveX", direction.x);
        animator.SetFloat("MoveY", direction.y);
        animator.SetBool("Moving", true);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player")){
    //        moving = true;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        moving = false;
    //        animator.SetBool("Moving", false);
    //    }
    //}
}
