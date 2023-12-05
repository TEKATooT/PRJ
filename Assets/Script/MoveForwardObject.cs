using UnityEngine;

public class MoveForwardObject : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _increaseSpeed;
    [SerializeField] private Vector3 _targetAngle;
    [SerializeField] private Vector3 _needSize;

    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
