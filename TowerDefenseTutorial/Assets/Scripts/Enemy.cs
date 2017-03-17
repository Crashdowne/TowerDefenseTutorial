using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;
    public int health = 100;
    public int value = 50;
    public GameObject deathEffect;

    private Transform target;
    private int waypointIndex = 0;

	// Use this for initialization
	void Start ()
    {
        target = Waypoints.waypoints[0];	
	}
	
    public void TakeDamage (int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die ()
    {
        PlayerStats.money += value;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

	// Update is called once per frame
	void Update ()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
	}

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length -1)
        {
            EndPath();
            return;
        }
        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }

    void EndPath ()
    {
        PlayerStats.lives--;
        Destroy(gameObject);   
    }
}
