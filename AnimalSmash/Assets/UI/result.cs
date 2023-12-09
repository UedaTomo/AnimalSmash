using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class result : MonoBehaviour
{
    //bool endtrigger = false;
    Button Reselect;
    Button Exit;

    void Start()
    {
        Reselect = GameObject.Find("/Canvas/ReSelectButton").GetComponent<Button>();
        Exit = GameObject.Find("/Canvas/ExitButton").GetComponent<Button>();
        //StartCoroutine("resultgame");

        Reselect.Select();
    }

    //void Update()
    //{
            // エスケープキーが押されたらゲームを終了する
      //      if (Input.GetKeyDown(KeyCode.Escape))
        //    {
//#if UNITY_EDITOR
  //          UnityEditor.EditorApplication.isPlaying = false;
            // 実行中のビルドではアプリケーションを終了する
//#else
//                Application.Quit();
//#endif
//            }
//            else if (Input.GetKey(KeyCode.Space))
//            {
//                SceneManager.LoadScene("title");
 //           }
//    }

    public void ReselectGame()
    {
        //ステージセレクトシーンへ移動
        SceneManager.LoadScene("stageselect");
    }


    public void ExitGame()
    {
        //アプリを終了
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }

    /*IEnumerator resultgame()
    {
        Debug.Log("aaa");
        yield return new WaitForSeconds(1);

        endtrigger = true;

        yield break;

    }*/
}