using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y > ScoreManager.heightScore)
        {
            ScoreManager.heightScore = (int)transform.position.y;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Apple은 점수 30 증가
        if (collision.CompareTag("Apple"))
        {
            ScoreManager.appleScore += 30;
            Destroy(collision.gameObject);
        }
        //WormApple은 점수 10 감소
        else if (collision.CompareTag("WormApple"))
        {
            ScoreManager.appleScore -= 10;
            Destroy(collision.gameObject);
        }
    }
}
