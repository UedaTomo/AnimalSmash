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
        isSceneChange = false;//�V�[���؂�ւ��͏�����false
        SheepSize = GameObject.Find("/Canvas/Image").GetComponent<RectTransform>();

        StageSelectButton = GameObject.Find("/Canvas/StageSelectButton").GetComponent<Button>();
        TutrialButton = GameObject.Find("/Canvas/TutrialButton").GetComponent<Button>();
        ExitButton = GameObject.Find("/Canvas/ExitButton").GetComponent<Button>();
        //Debug.Log("select ok");
        //�����̓X�e�[�W�Z���N�g��I��
        StageSelectButton.Select();
    }

    public void SelectStage()
    {
        //StartCoroutine(ApproachingSheep_S());
        //�X�e�[�W�Z���N�g�V�[���ֈړ�
        SceneManager.LoadScene("stageselect");
    }

    public void ExitGame()
    {
        //Debug.Log("Exit OK");
        //�A�v�����I��
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
#endif
    }

    public void Tutorial()
    {
        //StartCoroutine(ApproachingSheep_T());
        //�`���[�g���A���V�[���ֈړ�
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
