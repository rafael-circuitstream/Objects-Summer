using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private List<Enemy> allSpawnedEnemies = new List<Enemy>();
    [SerializeField] private List<Transform> allSpawnPoints = new List<Transform>();

    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private ItemSpawnerManager itemSpawner;

    public Action OnGameStart;
    public Action OnGameEnd;



    public static GameManager Instance;

    private void Awake()
    {
        if(Instance != null )
        {
            Debug.LogError("There is another Game Manager as Instance");
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        FindAnyObjectByType<Player>().health.OnHealthZero += EndGame;
        StartCoroutine(SpawnEnemiesCoroutine());
        Debug.Log("Hello!");
    }

    void SpawnSingleEnemy()
    {

        Enemy clonedEnemy = Instantiate(enemyPrefab);
        
        Transform randomSpawnPoint = allSpawnPoints[UnityEngine.Random.Range(0, allSpawnPoints.Count)];
        clonedEnemy.transform.position = randomSpawnPoint.position;

        allSpawnedEnemies.Add(clonedEnemy);

        clonedEnemy.health.OnHealthZero +=
            (() =>
            {
                scoreManager.AddScore(10);
                allSpawnedEnemies.Remove(clonedEnemy);

                itemSpawner.TrySpawnItem(clonedEnemy.transform.position);

                clonedEnemy.Explode();
            });
    }


    void EndGame()
    {
        Debug.LogWarning("GameOver");
        OnGameEnd?.Invoke();
        
    }


    IEnumerator SpawnEnemiesCoroutine()
    {
        OnGameStart?.Invoke();

        while (true)
        {
            if(allSpawnedEnemies.Count < 2)
            {
                SpawnSingleEnemy();
                yield return new WaitForSeconds(UnityEngine.Random.Range(2f, 3f));
            }



            yield return null;

        }

        //FindAnyObjectByType<Player>().Attack();
        //Camera.main.orthographicSize = 10f;
    }


    private void Update()
    {
        //lerpedColor = Color.Lerp(Color.red, Color.green, numberInterpolation);
        
    }
}
