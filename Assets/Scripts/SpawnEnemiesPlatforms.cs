using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesPlatforms : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public List<Transform> points = new List<Transform>();

    private GameObject currentEnemy;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Spawn()
    {
        if (currentEnemy == null)
        {
            CreateEnemy();
        }
    }

    private void CreateEnemy()
    {
        Transform randomPoint = points[Random.Range(0, points.Count)];
        GameObject e = Instantiate(enemies[Random.Range(0, enemies.Count)], randomPoint.position, randomPoint.rotation);
        currentEnemy = e;
    }
}
