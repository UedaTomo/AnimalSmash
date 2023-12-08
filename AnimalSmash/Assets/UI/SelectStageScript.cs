using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SelectStageScript : MonoBehaviour
{
    Button stage1;
    Button stage2;
    Button stage3;

    // Start is called before the first frame update
    void Start()
    {
        stage1 = GameObject.Find("/Canvas/Stage1").GetComponent<Button>();
        stage2 = GameObject.Find("/Canvas/Stage2").GetComponent<Button>();
        stage3 = GameObject.Find("/Canvas/Stage3").GetComponent<Button>();
        //Debug.Log("select ok");
        stage1.Select();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SelectStage1()
    {
        //SceneManager.LoadScene("");
    }

    void SelectStage2() 
    {
        //SceneManager.LoadScene("");
    }

    void SelectStage3()
    {
        //SceneManager.LoadScene("");
    }
}
