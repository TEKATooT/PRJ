using UnityEngine;
using DG.Tweening;

public class ObjectIncrease : MonoBehaviour
{
    [SerializeField] float _increaseSpeed;
    [SerializeField] private float _endSize;

    private void Start()
    {
        gameObject.transform.DOScale(_endSize, _increaseSpeed);
    }
}
