using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicZombie : Enemy
{
    private Vector3 movement = Vector3.zero;
    private Vector3 direction = Vector3.zero;
    private bool moving = false;
    private float timeBetweenAttacks = 1f;
    [SerializeField] private float timePastAttack = 0f;
    [SerializeField] private GameObject weapon;
    [SerializeField] private int damage;


    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public override void Movement()
    {
        base.Movement();
        direction = player.transform.position - transform.position;
        Vector3.Normalize(direction);
        if (Vector3.Distance(transform.position, player.transform.position) < 0.5f)
        {
            timePastAttack += Time.deltaTime;
            if (timePastAttack > timeBetweenAttacks)
            {
                if(animator.GetBool("Attack") == false) { 
                    animator.SetBool("Attack", true); 
                }
                player.GetComponent<PlayerHealth>().TakeDamage(damage);
                timePastAttack = 0f;
            }
        }
        else
        {
            if (animator.GetBool("Attack") == true)
            {
                animator.SetBool("Attack", false);
            }
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            if (timePastAttack != 0f)
            {
                timePastAttack = 0f;
            }
        }
        //direction = movement.normalized;
        //enemyRigidBody.MovePosition(movement);
        if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
            weapon.transform.localScale = new Vector3(-1f, 1f , 1f);
        }
        else
        {
            spriteRenderer.flipX = false;
            weapon.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        animator.SetFloat("MoveX", direction.x);
        animator.SetFloat("MoveY", direction.y);
    }
}
