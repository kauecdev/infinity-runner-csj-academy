using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public float spawnTime;

    private float timeCount;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        
        if (timeCount >= spawnTime)
        {
            SpawnEnemy();
            timeCount = 0f;
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemies[Random.Range(0, enemies.Count)], transform.position + new Vector3(0, Random.Range(0f, 3f), 0), transform.rotation);
    }
}
