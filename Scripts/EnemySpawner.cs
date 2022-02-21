using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemy;
    
    public float timeMin = 0.1f, timeMax = 0.3f;
    public int maxEnemies = 3;

    public BoxCollider2D boxCollider;

    public float startDelay = 1;
    public int waveCount = 5;
    public int currentWave = 0;

    List<GameObject> currentEnemies = new List<GameObject>();

    [SerializeField]
    private TMP_Text scoreText;
    int score;

    public InGameMenu winScreen;
    public Button menuButton;

    ScoreSystem scoreSystem;

    // Start is called before the first frame update
    void Start()
    {
        scoreSystem = FindObjectOfType<ScoreSystem>();
        score = scoreSystem.currentScore;
        StartCoroutine(SpawnWaveWithDelay(startDelay));
    }

    private IEnumerator SpawnWaveWithDelay(float startDelay)
    {
        currentWave++;
        yield return new WaitForSeconds(startDelay);
        float minX = boxCollider.bounds.min.x;
        float maxX = boxCollider.bounds.max.x;
        
        for (int i = 0; i < maxEnemies; i++)
        {
            Vector3 spawnPoint = new Vector3(UnityEngine.Random.Range(minX, maxX), transform.position.y, 0);
            GameObject newEnemy = Instantiate(enemy.gameObject, spawnPoint, Quaternion.Euler(0, 0, -90));
            currentEnemies.Add(newEnemy);
            newEnemy.GetComponent<Enemy>().enemySpawner = this;
            yield return new WaitForSeconds(UnityEngine.Random.Range(timeMin, timeMax));
        }
        
    }

    public void EnemyKilled(Enemy enemy, bool playerKill)
    {
        if (currentEnemies.Remove(enemy.gameObject))
        {
            if (playerKill)
            {
                score += 100;
                scoreText.text = score + "";
            }

            if (currentEnemies.Count == 0)
            {
                if (currentWave == waveCount)
                {
                    Debug.Log("You win");
                    scoreSystem.SetScore(score);
                    winScreen.Toggle();
                    menuButton.interactable = false;
                    return;
                }
                StartCoroutine(SpawnWaveWithDelay(0.5f));
            }
        }
        
    }
}
