using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombScript : MonoBehaviour
{
    [SerializeField] private GameObject _redZone;
    [SerializeField] private Transform _redPoint;
    [SerializeField] private Transform _bossAttackPoint;
    [SerializeField] private Transform _center;
    [SerializeField] private Transform _bossPoint;
    public float speed = 6.0f;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _redZone = Instantiate(_redZone, _redPoint.position, _redPoint.rotation);
        distance = Vector3.Distance(_bossPoint.position, _bossAttackPoint.position);
        float interpolatedValue = (Time.time * speed) / distance;
        transform.position = Vector3.Slerp(_bossPoint.position, _bossAttackPoint.position, interpolatedValue);
        
    }
}
