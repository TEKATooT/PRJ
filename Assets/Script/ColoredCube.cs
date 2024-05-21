using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Renderer))]
public class ColoredCube : MonoBehaviour
{
    private Renderer _renderer;

    private bool _isColored = false;

    public event UnityAction<ColoredCube> Ñolored;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        _renderer.material.color = Color.white;

        _isColored = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_isColored)
        {
            if (collision.collider.TryGetComponent(out Plane plane))
            {
                _renderer.material.color = plane.Color;

                _isColored = true;

                Ñolored.Invoke(this);
            }
        }
    }
}
