using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Spawner : MonoBehaviour
{
    public static int EnemiesAlive;

    public Wave[] waves;
    //public GameObject[] enemyList;
    public Transform spawnerPoint;

    private int timeBetweenWaves;
    private float countdown;
    private int waveNumber;

    private GameManager gameManager;

    public TextMeshProUGUI countdownText;
    // Start is called before the first frame update
    void Start()
    {
        waveNumber = 0;
        timeBetweenWaves = 5;
        countdown = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }
        if (waveNumber == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
            return;
        }
        if (GameManager.endGame)
        {
            this.enabled = false;
            return;
        }
        if (countdown <= 0)
        {
            StartCoroutine("EnemySpawner");
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        countdownText.text = string.Format("{0:00.00}", countdown);
    }
    IEnumerator EnemySpawner()
    {
        PlayerStates.rounds++;
        //enemyQuantity = 4 + waveNumber;
        Wave wave = waves[waveNumber];
        for (int i = 0; i < wave.count; i++)
        {
            EnemySpawner(wave.enemy);
            yield return new WaitForSeconds(1 / wave.rate);
        }
        waveNumber++;
    }

    private void EnemySpawner(GameObject enemy)
    {
        Instantiate(enemy, spawnerPoint.position, spawnerPoint.rotation);
        EnemiesAlive++;
    }
}
