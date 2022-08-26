using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform target;

    [Header("Attributes")]

    public float range;
    public Transform gunRotation;

    public float fireRate = 1f;
    public float fireCountdown = 0f;
    public GameObject bulletPrefabs;
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 dir = target.position - gunRotation.transform.position;
        Debug.DrawRay(gunRotation.position, dir, Color.red);

        gunRotation.rotation = Quaternion.LookRotation(dir);

        if(fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        //tao vien dan
        GameObject bulletGO = Instantiate(bulletPrefabs, firePoint.position, firePoint.rotation);
        //truy cap den script cua bullet va dung method Seek(target) de truyen muc tieu cho bullet
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }
    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float minDistanceToEnemy = Mathf.Infinity;
        GameObject nearEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(enemy.transform.position, transform.position);
            if (distanceToEnemy <= minDistanceToEnemy)
            {
                minDistanceToEnemy = distanceToEnemy;
                nearEnemy = enemy;
            }
        }
        if (nearEnemy != null && minDistanceToEnemy < range)
        {
            target = nearEnemy.transform;
        }


    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
