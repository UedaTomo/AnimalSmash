using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public enum BossState
{
    WAIT,         //ë“ã@
    ATTACK,       //çUåÇ
}
public class BossScript : MonoBehaviour
{
    public GameObject _bombPrefab;
    public Transform _bossPoint;
    public int _bossHp = 5;
    public Slider _bossSlider;
    int currentHp;
    // Start is called before the first frame update
    void Start()
    {
        Attack();
        currentHp = _bossHp;

    }
    void SetAi()
    {

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
            Destroy(gameObject);
        }
        _bossSlider.value = (int)currentHp / (int)_bossHp; ;
    }
    void Attack()
    {
        //bombPrefab = Instantiate(_bombPrefab, _bossPoint.position, _bossPoint.rotation); //îöíeê∂ê¨
    }
}
