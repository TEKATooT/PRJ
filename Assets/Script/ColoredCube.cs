using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColoredCube : MonoBehaviour
{
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Plane _plane))
            _renderer.material.color = _plane.Color;
    }
}
