using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject startImage;

    bool gameStarted = false;

    void Start()
    {
        startImage.SetActive(true);
    }

    void Update()
    {
        //게임 시작(마우스 클릭)
        if (Input.GetMouseButtonDown(0) && !gameStarted)
        {
            StartGame();
        }
    }

    void StartGame()
    {
        gameStarted = true;
        startImage.SetActive(false);
    }
}
