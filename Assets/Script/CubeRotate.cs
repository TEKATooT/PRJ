using UnityEngine;

public class CubeRotate : MonoBehaviour
{
    [SerializeField] Vector3 _targetAngle;
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Rotate(_targetAngle, _speed * Time.deltaTime);
    }
}
