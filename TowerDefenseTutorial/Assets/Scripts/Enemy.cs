﻿using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;

    public float startHealth = 100f;
    private float health;
    public int value = 50;
    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image healthBar;

    private bool isDead = false;

    void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage (float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0f && isDead == false)
        {
            Die();
        }
    }

    void Die ()
    {
        isDead = true;
        PlayerStats.money += value;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
        WaveSpawner.EnemiesAlive--;
    }

    public void Slow (float percent)
    {
        speed = startSpeed * (1f - percent);
    }
}
