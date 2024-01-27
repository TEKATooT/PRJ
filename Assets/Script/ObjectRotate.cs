using UnityEngine;
using DG.Tweening;

public class ObjectRotate : MonoBehaviour
{
    [SerializeField] Vector3 _toAngle;
    [SerializeField] float _rotateSpeed;

    private void Start()
    {
        gameObject.transform.DORotate(_toAngle, _rotateSpeed);
    }
}
