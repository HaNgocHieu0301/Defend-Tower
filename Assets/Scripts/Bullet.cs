using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 10f;

    public int damage = 50;

    public GameObject effect;
    public float explosionRadius = 0f;
    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        //neu muc tieu null thi destroy bullet
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        //bullet bay den doi tuong 
        Vector3 dir = target.position - transform.position; //vector tu vien dan toi doi tuong
        float distance = speed * Time.deltaTime; //quang duong bullet bay duoc trong 1s
        if(dir.magnitude <= distance) //so sanh neu kcach tu vien dan toi doi tuong <= -> k hieu
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distance, Space.World);
    }

    void HitTarget()
    {
        GameObject impactEffect = Instantiate(effect, transform.position, transform.rotation);
        Destroy(impactEffect, 2f);
        if(explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target.gameObject);
        }
        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        //kiem tra trong 1 sphere co ban kinh bang exploreRadius
        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.gameObject);
            }
        }
    }

    void Damage(GameObject enemy)
    {
        EnemyController e = enemy.GetComponent<EnemyController>();
        if(e != null)
        {
            e.TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
