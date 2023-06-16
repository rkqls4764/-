using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int totalScore;
    public static int heightScore;
    public static int appleScore;

    void Awake()
    {
        heightScore = 0;
        appleScore = 0;
        totalScore = 0;
    }

    void Update()
    {
        totalScore = heightScore + appleScore;
    }
}
