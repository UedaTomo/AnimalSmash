using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;


public class result : MonoBehaviour
{
    //bool endtrigger = false;
    public TextMeshProUGUI combo;
    public TextMeshProUGUI time;
    Button Reselect;
    Button Exit;
    int MaxCombo = damage._maxcombo;
    int minutes = PlayerScript.resultminutes;
    float seconds = PlayerScript.resultseconds;

    private static bool clear = false;

    void Start()
    {
        Reselect = GameObject.Find("/Canvas/ReSelectButton").GetComponent<Button>();
        Exit = GameObject.Find("/Canvas/ExitButton").GetComponent<Button>();
        //StartCoroutine("resultgame");
        combo.text = "" + (int)MaxCombo;
        time.text = minutes.ToString("00") + ":" + ((int)seconds).ToString("00");
        Reselect.Select();
    }

    //void Update()
    //{
            // �G�X�P�[�v�L�[�������ꂽ��Q�[�����I������
      //      if (Input.GetKeyDown(KeyCode.Escape))
        //    {
//#if UNITY_EDITOR
  //          UnityEditor.EditorApplication.isPlaying = false;
            // ���s���̃r���h�ł̓A�v���P�[�V�������I������
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
        //�X�e�[�W�Z���N�g�V�[���ֈړ�
        SceneManager.LoadScene("stageselect");
        damage._maxcombo = 0;
        PlayerScript.resultminutes = 0;
        PlayerScript.resultseconds = 0;
    }


    public void ExitGame()
    {
        //�A�v�����I��
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
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