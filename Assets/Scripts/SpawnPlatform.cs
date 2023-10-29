using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>();
    public float offset;
    
    private List<Transform> currentPlatforms = new List<Transform>();
    private Transform player;
    private Transform currentPlatformPoint;
    private int platformIndex;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < platforms.Count; i++)
        {
            Transform platformTransform = Instantiate(platforms[i], new Vector2(i * 30, 0), transform.rotation).transform;
            currentPlatforms.Add(platformTransform);
            offset += 30f;
        }

        SetNewCurrentPlatformPoint();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float distance = player.position.x - currentPlatformPoint.position.x;

        if (distance >= 1)
        {
            Recycle(currentPlatforms[platformIndex].gameObject);
            platformIndex++;

            if (platformIndex > currentPlatforms.Count)
            {
                platformIndex = 0;
            }

            SetNewCurrentPlatformPoint();
        }
    }

    private void SetNewCurrentPlatformPoint()
    {
        currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint;
    }

    public void Recycle(GameObject platform)
    {
        platform.transform.position = new Vector2(offset, 0f);
        offset += 30f;
    }
}
