using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRun : MonoBehaviour
{
    private Quaternion _startAngles;
    private bool _isFinish;

    [SerializeField] Quaternion _targetAngles;
    [SerializeField] private float _speed;

    // Quaternion quaternion = Quaternion.Euler

    void Start()
    {
        // _startAngles = transform.localRotation;
    }

    void Update()
    {
        //if (_isFinish == false)
        //{
           // transform.localRotation = Quaternion.FromToRotation(transform.rotation, _startAngles, _speed * Time.deltaTime);

        //    if (transform.position == _targetAngles)
        //        _isFinish = true;
        //}

        //if (_isFinish == true)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, _startAngles, _speed * Time.deltaTime);

        //    if (transform.position == _startAngles)
        //        _isFinish = false;
        //}
    }
}
