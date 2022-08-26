using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    public static Transform[] waypoints;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = new Transform[transform.childCount];
        for (int i = waypoints.Length- 1; i >= 0; i--)
        {
            waypoints[i] = transform.GetChild(i);
        }
    }
    public static Vector3 getNextPointway(int index)
    {
        return waypoints[index].position;
    }

    public static void EndPath(GameObject obj)
    {
        Destroy(obj);
        PlayerStates.lives--;
        Spawner.EnemiesAlive--;
    }
}
