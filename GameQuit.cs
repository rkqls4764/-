using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQuit : MonoBehaviour
{
    void Update()
    {
        //게임 종료(ESC 누름)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }       
    }

    void ExitGame()
    {
        // 유니티 에디터에서 실행 중인 경우
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        // 빌드된 게임에서 실행 중인 경우
        #else
            Application.Quit();
        #endif
    }
}
