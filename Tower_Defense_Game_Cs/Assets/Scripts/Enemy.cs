using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float enemySpeed = 10f;
    public Image healthBar;
    private Transform target;
    private int waypointIndex = 0;
    private float fill;
    public static int waveIndexToHealth;
    private float fullHealth = waveIndexToHealth;
    private float enemyHealth;
    void Start()
    {
        enemyHealth = fullHealth;
        target = Waypoints.waypoints[0];
        
    }
    void Update()
    {
        fill = enemyHealth / fullHealth;
        healthBar.fillAmount = fill;
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemySpeed * Time.deltaTime, Space.World);
        if (Vector3.Distance(target.position,transform.position)<0.2f)
        {
            GetNextWaypoint();
        }
    }
    public void TakeDamage(int amount)
    {
        enemyHealth -= amount;
        Debug.Log(enemyHealth);
        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        WaveSpawner.currency += 50;
        Destroy(gameObject);
    }

    private void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }
}
