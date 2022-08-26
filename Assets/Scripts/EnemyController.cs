using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyController : MonoBehaviour
{
    public float speed = 10f;
    public int startHealth = 100;
    public int health;
    public int value = 50;

    public Image healthBar;

    private bool isDead = false;
    private int indexWayPoint;
    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        indexWayPoint = EnemyMoving.waypoints.Length - 1;
        target = EnemyMoving.waypoints[indexWayPoint].position;
        health = startHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        healthBar.fillAmount = health/startHealth;

        if (health <= 0 && !isDead)
        {
            Died();
        }
    }
    public void Died()
    {
        isDead = true;
        PlayerStates.money += value;
        Spawner.EnemiesAlive--;
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.endGame)
        {
            return;
        }
        //Debug.Log(EnemyMoving.waypoints[indexWayPoint].name);
        Vector3 arrivePos = target - transform.position;
        transform.Translate(speed * Time.deltaTime * arrivePos.normalized, Space.World);
        //Debug.Log(indexWayPoint);
        if (Vector3.Distance(transform.position, target) <= 0.4f)
        {
            indexWayPoint--;
            if (indexWayPoint < 0)
            {
                EnemyMoving.EndPath(gameObject);
                return;
            } 
            target = EnemyMoving.getNextPointway(indexWayPoint);
        }
    }
}
