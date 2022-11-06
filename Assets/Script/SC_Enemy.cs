using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Enemy : MonoBehaviour
{
    [Header("Base Enemy options")]
    [SerializeField] float speed = 10f;
    [SerializeField] public int health = 100;

    private Transform target;
    private int waypointIndex = 0;

    void Start()
    {
        target = SC_Waypoints.points[0];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.3f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if(waypointIndex >= SC_Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        waypointIndex++;
        target = SC_Waypoints.points[waypointIndex];
    }

    private void EndPath()
    {
        SC_PlayerStats.health--;
        Destroy(gameObject);
    }
}
