using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Renderer))]
public class ColorChencher : MonoBehaviour
{
    [SerializeField] float _chencherSpeed;
    [SerializeField] private Color _needColor = Color.green;
    [SerializeField] private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();

        _renderer.material.DOColor(_needColor, _chencherSpeed);
    }
}
