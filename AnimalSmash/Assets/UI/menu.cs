using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    Button StageSelectButton;
    Button TutrialButton;
    Button ExitButton;

    public void Start()
    {
        StageSelectButton = GameObject.Find("/Canvas/StageSelectButton").GetComponent<Button>();
        TutrialButton = GameObject.Find("/Canvas/TutrialButton").GetComponent<Button>();
        ExitButton = GameObject.Find("/Canvas/ExitButton").GetComponent<Button>();
        //Debug.Log("select ok");
        //初期はステージセレクトを選択
        StageSelectButton.Select();
    }

    private void Update()
    {
        
    }
    public void SelectStage()
    {
        //ステージセレクトシーンへ移動
        SceneManager.LoadScene("stageselect");
    }

    public void ExitGame()
    {
        //Debug.Log("Exit OK");
        //アプリを終了
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }

    public void Tutrial()
    {
        //チュートリアルシーンへ移動
        SceneManager.LoadScene("yasuda1");
    }
}
