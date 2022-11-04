using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Bullet : MonoBehaviour
{
    [Header("Bullet options")]
    [SerializeField] public float bulletSpeed = 50f;
    [SerializeField] public GameObject fireEffect;
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
    }

    void HitTarget()
    {
        Debug.Log("Méchant toucher");
        GameObject fireEffectInst = (GameObject)Instantiate(fireEffect, transform.position, transform.rotation);
        Destroy(fireEffectInst, 2f);
        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
