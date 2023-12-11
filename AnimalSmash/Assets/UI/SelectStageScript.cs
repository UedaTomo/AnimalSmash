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
    Button Back;
    [SerializeField] private Image sheep_Image;
    [SerializeField] private Image rabbit_Image;
    public RectTransform SheepSize;
    public RectTransform RabbitSize;
    int i = 0;

    private bool isSceneChange;
    // Start is called before the first frame update
    public void Start()
    {
        isSceneChange = false;//�V�[���؂�ւ��͏�����false
        SheepSize = GameObject.Find("/Canvas/SheepImage").GetComponent<RectTransform>();
        RabbitSize = GameObject.Find("/Canvas/RabbitImage").GetComponent<RectTransform>();
        stage1 = GameObject.Find("/Canvas/Stage1").GetComponent<Button>();
        stage2 = GameObject.Find("/Canvas/Stage2").GetComponent<Button>();
        stage3 = GameObject.Find("/Canvas/Stage3").GetComponent<Button>();
        Back  = GameObject.Find("/Canvas/BackMenuButton").GetComponent<Button>();
        //Debug.Log("select ok");
        stage1.Select();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectStage1()
    {

        //SceneManager.LoadScene("S1shibato");
        StartCoroutine(ApproachingSheep_S1());
    }

    public void SelectStage2() 
    {

        //SceneManager.LoadScene("S2shibato");
        StartCoroutine(ApproachingSheep_S2());
    }

    public void SelectStage3()
    {
        //SceneManager.LoadScene("");
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("menu");
    }

    private IEnumerator ApproachingSheep_S1()
    {
        while (!isSceneChange)
        {
            i += 150;
            SheepSize.sizeDelta = new Vector2(i, i);
            if (i >= 2000)
            {
                isSceneChange = true;
            }
            yield return new WaitForSeconds(0.1f);
        }
        SceneManager.LoadScene("S1shibato");
    }

    private IEnumerator ApproachingSheep_S2()
    {
        while (!isSceneChange)
        {
            i += 150;
            RabbitSize.sizeDelta = new Vector2(i, i);
            if (i >= 2000)
            {
                isSceneChange = true;
            }
            yield return new WaitForSeconds(0.1f);
        }
        SceneManager.LoadScene("S2shibato");
    }
}
