using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed;
    protected Rigidbody2D enemyRigidBody;
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;
    protected Vector3 lastDirection = Vector3.zero;
    [SerializeField] protected int health;
    public GameObject player;
    // Start is called before the first frame update
    public Slider healthSlider;
    public List<GameObject> toDisable;

    public virtual void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<PlayerMovement>().gameObject;
        healthSlider.minValue = 0;
        healthSlider.maxValue = health;
        healthSlider.value = health;
        
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        healthSlider.value = health;
        if (health <= 0)
        {
            foreach(GameObject item in toDisable)
            {
                item.SetActive(false);
            }
            animator.SetTrigger("Dead");
        }
    }

    public virtual void Movement()
    {

    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    

}
