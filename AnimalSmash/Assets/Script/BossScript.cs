using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;
using UnityEngine.SceneManagement;

public enum BossState
{
    WAIT,         //ë“ã@
    ATTACK,       //çUåÇ
}
public class BossScript : MonoBehaviour
{
    public GameObject _bombPrefab;
    public Transform _bossPoint;
    public int _bossHp = 500;
    public Slider _bossSlider;
    public static int currentHp;
    public GameObject _smash;
    public GameObject _bossSmash;
    public GameObject _playerObj;

    // Start is called before the first frame update
    void Start()
    {
        Attack();
        currentHp = _bossHp;
    }
    public void HP(int damage,int damageLevel)
    {
        currentHp -= damage+damageLevel;
        Debug.Log("a");
    }
    // Update is called once per frame
    void Update()
    {
        if(currentHp <= 0)
        {
            OnDestroy();
            SceneManager.LoadScene("WinResult");

        }
        _bossSlider.value = (int)currentHp;
    }
    private void OnDestroy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemy in enemies)
        {
            Vector3 effectPosition = new Vector3(enemy.transform.position.x, enemy.transform.position.y + 1f, enemy.transform.position.z);
            //Instantiate(_smash, effectPosition, Quaternion.identity);
            Destroy(enemy);
            //_playerObj.GetComponent<PlayerScript>().GameClear();
        }
        Vector3 bossEffectPosition = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z);
        //Instantiate(_bossSmash, bossEffectPosition, Quaternion.identity);
        //Destroy(gameObject);
    }
    void Attack()
    {
        //bombPrefab = Instantiate(_bombPrefab, _bossPoint.position, _bossPoint.rotation); //îöíeê∂ê¨
    }
}