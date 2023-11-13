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
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            // 実行中のビルドではアプリケーションを終了する
#else
            Application.Quit();
#endif
        }
        else if(Input.anyKey)
        {
            SceneManager.LoadScene("title");
        }
    }
}