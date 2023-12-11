using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    //[SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button BackSelectButton;
    [SerializeField] private Button ReloadButton;

    public bool enemy_pause;

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        enemy_pause = false;
        //pauseButton.onClick.AddListener(Pause);
        //resumeButton.onClick.AddListener(Resume);
    }

    // Update is called once per frame
     public void Update()
    {
        if (Input.GetKey("joystick button 7") || Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("ok");
            enemy_pause = true;
            pausePanel.SetActive(true);
            resumeButton.Select();
            Time.timeScale = 0;  // 時間停止
            //Pause();
        }
        Debug.Log(enemy_pause);

    }

    private void Pause()
    {
        
    }

    public void Resume()
    {
        enemy_pause = false;
        Debug.Log("false ok");
        Time.timeScale = 1;  // 再開
        Debug.Log("time ok");
        pausePanel.SetActive(false);
        Debug.Log("restart ok");
    }

    public void BackSelect()
    {
        //ステージセレクトに戻る
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        SceneManager.LoadScene("stageselect");
    }

    public void Reload()
    {
        //ゲームリセット
        Time.timeScale = 1;  
        pausePanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
