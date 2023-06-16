using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnApple : MonoBehaviour
{
    public GameObject player;
    public GameObject applePrefab1, applePrefab2;
    public float minX = -3.0f;
    public float maxX = 3.0f;
    public float minY = 2.0f;
    public float maxY = 5.0f;
    public float spawnDelay = 2.0f;

    float lastSpawnPosY;

    GameObject newApplePrefab;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lastSpawnPosY = player.transform.position.y;
    }

    void Update()
    {
        if (Time.time >= spawnDelay)
        {
            SpawnNewApple();
            spawnDelay += Random.Range(1.0f, 3.0f);
        }
    }

    //사과 생성 함수
    public void SpawnNewApple()
    {
        if (Random.Range(0, 2) == 0)
        {
            newApplePrefab = applePrefab1;
        }
        else
        {
            newApplePrefab = applePrefab2;
        }

        float spawnPosX = Random.Range(minX, maxX);
        float spawnPosY = lastSpawnPosY + Random.Range(minY, maxY);

        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, transform.position.z);
        Instantiate(newApplePrefab, spawnPos, Quaternion.identity);

        lastSpawnPosY = spawnPosY;
    }
}
