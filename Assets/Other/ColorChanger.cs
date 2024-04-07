using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Renderer))]
public class ColorChanger : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Color _needColor = Color.green;
    [SerializeField] private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();

        _renderer.material.DOColor(_needColor, _speed);
    }
}
