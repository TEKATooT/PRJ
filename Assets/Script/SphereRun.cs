using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereRun : MonoBehaviour
{
    private Vector3 _startPosition;
    private bool _isFinish;

    [SerializeField] Vector3 _targetPosition;
    [SerializeField] private float _speed;

    void Start()
    {
        _startPosition = transform.position;
    }

    void Update()
    {
        if (_isFinish == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

            if (transform.position == _targetPosition)
                _isFinish = true;
        }

        if (_isFinish == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _startPosition, _speed * Time.deltaTime);

            if (transform.position == _startPosition)
                _isFinish = false;
        }
    }
}
