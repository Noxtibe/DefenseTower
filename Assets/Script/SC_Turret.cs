using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Turret : MonoBehaviour
{
    [Header("Turret options")]
    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] public Transform target;
    [SerializeField] public Transform partToRotate;
    [SerializeField] public Transform firePoint;
    [SerializeField] public string enemyTag = "Enemy";
    [SerializeField] public float range = 15f;
    [SerializeField] private float turnSpeed = 6f;
    [SerializeField] public float fireRate = 1f;
    [SerializeField] private float fireTimer = 0f;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in ennemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if(target == null)
        {
            return;
        }

        Vector3 dir  = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireTimer <= 0f)
        {
            Fire();
            fireTimer = 1 / fireRate;
        }
        fireTimer -= Time.deltaTime;
    }

    void Fire()
    {
        Debug.Log("Tir sur méchant");
        GameObject bulletOB = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        SC_Bullet bullet = bulletOB.GetComponent<SC_Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
