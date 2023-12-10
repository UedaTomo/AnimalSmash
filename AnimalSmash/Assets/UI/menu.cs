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
    [SerializeField] private Image sheep_Image;
    public RectTransform SheepSize;
    int i = 0;

    private bool isSceneChange;
    public void Start()
    {
        isSceneChange = false;//シーン切り替えは初期でfalse
        SheepSize = GameObject.Find("/Canvas/Image").GetComponent<RectTransform>();

        StageSelectButton = GameObject.Find("/Canvas/StageSelectButton").GetComponent<Button>();
        TutrialButton = GameObject.Find("/Canvas/TutrialButton").GetComponent<Button>();
        ExitButton = GameObject.Find("/Canvas/ExitButton").GetComponent<Button>();
        //Debug.Log("select ok");
        //初期はステージセレクトを選択
        StageSelectButton.Select();
    }

    public void SelectStage()
    {
        //StartCoroutine(ApproachingSheep_S());
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

    public void Tutorial()
    {
        //StartCoroutine(ApproachingSheep_T());
        //チュートリアルシーンへ移動
        //SceneManager.LoadScene("yasuda1");
    }

    private IEnumerator ApproachingSheep_S()
    {
        while (!isSceneChange)
        {
            i += 100;
            SheepSize.sizeDelta = new Vector2(i, i);
            if (i >= 1000)
            {
                isSceneChange = true;
            }
                yield return new WaitForSeconds(0.1f); 
        }
        SceneManager.LoadScene("stageselect");
    }

    private IEnumerator ApproachingSheep_T()
    {
        while (!isSceneChange)
        {
            i += 100;
            SheepSize.sizeDelta = new Vector2(i, i);
            if (i >= 1000)
            {
                isSceneChange = true;
            }
            yield return new WaitForSeconds(0.1f);
        }
        SceneManager.LoadScene("yasuda1");
    }
}
