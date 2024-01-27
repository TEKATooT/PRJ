using UnityEngine;
using DG.Tweening;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] private Vector3 _endPosition;

    private void Start()
    {
        gameObject.transform.DOMove(_endPosition, _moveSpeed);
    }
}
