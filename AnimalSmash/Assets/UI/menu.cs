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
        //�����̓X�e�[�W�Z���N�g��I��
        StageSelectButton.Select();
    }

    private void Update()
    {
        
    }
    public void SelectStage()
    {
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

    public void Tutrial()
    {
        //�`���[�g���A���V�[���ֈړ�
        SceneManager.LoadScene("yasuda1");
    }
}
