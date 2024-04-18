using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float movementChange = 0.1f;
    public float speed;
    Rigidbody2D playerRigidBody;
    Animator animator;
    SpriteRenderer spriteRenderer;
    Vector3 lastDirection = Vector3.zero;
    public int Total = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector3 change = new Vector3(moveX, moveY, 0);
        playerRigidBody.MovePosition(transform.position + change * speed * Time.deltaTime);
        if (moveX  < 0) {
            spriteRenderer.flipX = true;
        }else{
            spriteRenderer.flipX = false;
        }
        if(change !=  Vector3.zero)
        {
            animator.SetFloat("MoveX", moveX);
            animator.SetFloat("MoveY", moveY);
            animator.SetBool("Moving", true);
            lastDirection = change;
        }
        else
        {
            if (lastDirection.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
            animator.SetFloat("MoveX", lastDirection.x);
            animator.SetFloat("MoveY", lastDirection.y);
            animator.SetBool("Moving", false);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
        }
        //Debug.Log(moveX.ToString());
        //movementChange = Time.deltaTime*speed;
        //switch (Input.GetKeyDown(KeyCode.UpArrow) ? KeyCode.UpArrow :
        //       (Input.GetKeyDown(KeyCode.DownArrow) ? KeyCode.DownArrow :
        //       (Input.GetKeyDown(KeyCode.LeftArrow) ? KeyCode.LeftArrow :
        //        Input.GetKeyDown(KeyCode.RightArrow) ? KeyCode.RightArrow : 0)))
        //{
        //    case KeyCode.RightArrow:
        //        transform.position = new Vector3(transform.position.x + movementChange, transform.position.y, transform.position.z);
        //        break;
        //    case KeyCode.LeftArrow:
        //        transform.position = new Vector3(transform.position.x - movementChange, transform.position.y, transform.position.z);
        //        break;
        //    case KeyCode.UpArrow:
        //        transform.position = new Vector3(transform.position.x, transform.position.y + movementChange, transform.position.z);
        //        break;
        //    case KeyCode.DownArrow:
        //        transform.position = new Vector3(transform.position.x, transform.position.y - movementChange, transform.position.z);
        //        break;
        //}
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entering " + collision.name);
        if (collision.CompareTag("Breakeables"))
        {
            Total += collision.GetComponent<Obstacle>().getValue();
        
            Destroy(collision.gameObject);  
    
        }
    }

    //public void OnTriggerExit2D(Collider2D collision)
    //{
    //    Debug.Log("Exiting" + collision.name);
    //}

    //public void OnTriggerStay2D(Collider2D collision)
    //{
    //    Debug.Log("Near" + collision.name);
    //}
}
