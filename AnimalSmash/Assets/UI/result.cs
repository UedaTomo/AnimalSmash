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