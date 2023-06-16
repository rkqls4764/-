using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    BoxCollider2D collider;
    GameObject player;
    bool isStartTile = false;

    public float maxDistance = 10.0f;

    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        player = GameObject.FindWithTag("Player");

        if (CompareTag("StartTile"))
        {
            isStartTile = true;
        }
    }

    void Update()
    {
        if (transform.CompareTag("StartTile"))
        {
            float distance = Mathf.Abs(transform.position.y - player.transform.position.y);

            if (distance > maxDistance)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (transform.position.y >= other.transform.position.y)
            {
                collider.isTrigger = true;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (transform.position.y >= other.transform.position.y)
            {
                collider.isTrigger = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        collider.isTrigger = false;
    }
}
