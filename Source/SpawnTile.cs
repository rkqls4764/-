using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTile : MonoBehaviour
{
    public GameObject player;
    public GameObject tilePrefab1, tilePrefab2;
    public float minX = -3.0f;
    public float maxX = 3.0f;
    public float minY = 2.0f;
    public float maxY = 5.0f;
    public float spawnDelay = 2.0f;

    float tileWidth1, tileWidth2;
    float lastSpawnPosY;

    GameObject newTilePrefab;
    float newTileWidth;

    void Start()
    {
        tileWidth1 = tilePrefab1.GetComponentInChildren<SpriteRenderer>().bounds.size.x;
        tileWidth2 = tilePrefab2.GetComponentInChildren<SpriteRenderer>().bounds.size.x;
        player = GameObject.FindGameObjectWithTag("Player");
        lastSpawnPosY = player.transform.position.y;
    }

    void Update()
    {
        if (Time.time >= spawnDelay)
        {
            SpawnNewTile();
            spawnDelay += Random.Range(1.0f, 3.0f);
        }
    }

    //발판 생성 함수
    public void SpawnNewTile()
    {       
        if (Random.Range(0, 2) == 0)
        {
            newTilePrefab = tilePrefab1;
            newTileWidth = tileWidth1;
        }
        else
        {
            newTilePrefab = tilePrefab2;
            tileWidth2 = tileWidth2;
        }
        
        float spawnPosX = Random.Range(minX, maxX);
        float spawnPosY = lastSpawnPosY + Random.Range(minY, maxY);
        
        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, transform.position.z);
        Instantiate(newTilePrefab, spawnPos, Quaternion.identity);

        lastSpawnPosY = spawnPosY;
    }
}
