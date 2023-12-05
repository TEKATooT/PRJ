using UnityEngine;

public class CubeRun : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _increaseSpeed;
    [SerializeField] private Vector3 _targetAngle;
    [SerializeField] private Vector3 _needSize;

    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        transform.Rotate(_targetAngle, _rotateSpeed * Time.deltaTime);

        transform.localScale = Vector3.MoveTowards(transform.localScale, _needSize, _increaseSpeed * Time.deltaTime);
    }
}
