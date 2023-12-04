using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive;
    void Start()
    {
        EnemiesAlive = 0;
    }

    public Wave[] waves;

    public GameObject winPanel;

    public Transform spawnPoint;

    public bool waveComplete = false; 

    public float timeBetweenWaves = 2f;
    private float countdown = 2f;

    public Text waveCountdownText;

    private int waveIndex = 0;

    public void WaveFinish()
    {
        winPanel.SetActive(true);

    }

    void Update()
    {
        if (EnemiesAlive > 0)
        {
            Debug.Log("test");
            return;
        }

        if (countdown <= 0f)
        {
            if (waveIndex >= waves.Length) waveComplete = true;
            if (waveComplete)
            {
                WaveFinish();
            }
            else
            {
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
                return;
            }
            
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }


    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];
        for (int z = 0; z < wave.enemies.Length; z++)
        {
            for (int i = 0; i < wave.enemies[z].count; i++)
            {
                SpawnEnemy(wave.enemies[z].enemy);
                yield return new WaitForSeconds(1f / wave.spawnRate);
            }
            if (waveIndex == waves.Length)
            {
                Debug.Log("TODO - End Level");
                this.enabled = false;
            }
        }
        waveIndex++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }

}
