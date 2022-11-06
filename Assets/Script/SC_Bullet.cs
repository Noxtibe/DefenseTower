using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Bullet : MonoBehaviour
{
    [Header("Bullet options")]
    [SerializeField] public GameObject fireEffect;
    [SerializeField] public float bulletSpeed = 50f;
    [SerializeField] public float explosionRadius = 0f;
    [SerializeField] public int damage = 50;

    private Transform target;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = bulletSpeed * Time.deltaTime;
        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        Debug.Log("Méchant toucher");
        GameObject fireEffectInst = (GameObject)Instantiate(fireEffect, transform.position, transform.rotation);
        Destroy(fireEffectInst, 2f);

        if (explosionRadius > 0)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        SC_Enemy e = enemy.GetComponent<SC_Enemy>();
        if(e != null)
        {
            e.TakeDamage(damage);
        }
        else
        {
            Debug.Log("Pas de script Enemy sur l'ennemi !");
        }
        

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }


}
