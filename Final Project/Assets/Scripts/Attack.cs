using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
   public Animator animator;
    private void Start()
    {
        animator = GetComponentInParent<Animator>();
    }
    private void Update()
    {
        if (gameObject.name != "SideAttack")
        {
            return;
        }
        if (animator.GetFloat("MoveX") < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }else if(animator.GetFloat("MoveX")  > 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Breakeables"))
        {
            //Total += collision.GetComponent<Obstacle>().getValue();
            Destroy(collision.gameObject);
        }
    }

}
