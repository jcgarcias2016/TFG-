using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public Slider healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.minValue = 0;
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthSlider.value = health;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
