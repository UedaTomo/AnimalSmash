using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class result : MonoBehaviour
{
    void Update()
    {
        // エスケープキーが押されたらゲームを終了する
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEditor.EditorApplication.isPlaying = false;
            // 実行中のビルドではアプリケーションを終了する
            Application.Quit();
        }
        else if(Input.anyKey)
        {
            SceneManager.LoadScene("title");
        }
    }
}