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
            // �G�X�P�[�v�L�[�������ꂽ��Q�[�����I������
            if (Input.GetKeyDown(KeyCode.Escape))
            {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            // ���s���̃r���h�ł̓A�v���P�[�V�������I������
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