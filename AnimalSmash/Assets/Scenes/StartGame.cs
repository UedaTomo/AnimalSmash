using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("joystick button 1") || Input.GetKey("joystick button 2") || Input.GetKey("joystick button 3") || Input.GetKey("joystick button 4") 
            || (Input.GetKeyDown(KeyCode.Space)))
        {
            SceneManager.LoadScene("Main");
        }

        if (Input.GetKey(KeyCode.Escape))
        {

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
        }
    }
}
