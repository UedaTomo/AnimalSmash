using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class result : MonoBehaviour
{
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
        else if(Input.anyKey)
        {
            SceneManager.LoadScene("title");
        }
    }
}