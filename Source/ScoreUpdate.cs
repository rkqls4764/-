using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{
    Text scoreText;

    void Awake()
    {
        scoreText = GetComponent<Text>();
    }
    
    public void Update()
    {
        scoreText.text = "Score : " + ScoreManager.totalScore.ToString();
    }
}
