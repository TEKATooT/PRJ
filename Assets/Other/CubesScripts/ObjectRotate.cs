using UnityEngine;
using DG.Tweening;

public class ObjectRotate : MonoBehaviour
{
    [SerializeField] private Vector3 _toAngle;
    [SerializeField] private float _rotateSpeed;

    private void Start()
    {
        gameObject.transform.DORotate(_toAngle, _rotateSpeed);
    }
}
