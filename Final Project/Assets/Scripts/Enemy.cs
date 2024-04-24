using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    protected Rigidbody2D playerRigidBody;
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;
    protected Vector3 lastDirection = Vector3.zero;
    [SerializeField] protected int health;
    public GameObject player;
    // Start is called before the first frame update
    public virtual void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
