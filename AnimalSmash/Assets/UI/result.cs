using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class result : MonoBehaviour
{
    //bool endtrigger = false;

    void start()
    {
        //StartCoroutine("resultgame");
    }

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
            else if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene("title");
            }
    }

    /*IEnumerator resultgame()
    {
        Debug.Log("aaa");
        yield return new WaitForSeconds(1);

        endtrigger = true;

        yield break;

    }*/
}