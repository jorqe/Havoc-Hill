using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bosshealthbar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider easeHealthSlider;
    private float lerpSpeed = 0.005f;
    public float maxHealth = 50f;
    private float health;
    private BossEnemy bossEnemy;
    void Start()
    {
        bossEnemy = GetComponentInParent<BossEnemy>();
    }

    void Update()
    {
        health = bossEnemy.health;

        if (healthSlider.value != health) {
            healthSlider.value = health;
        }

        if (healthSlider.value != easeHealthSlider.value) {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, lerpSpeed);
        }
    }

    void takeDamage(float damage) {
        health -= damage;
    }
}
