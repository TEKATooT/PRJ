using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColoredCube : MonoBehaviour
{
    private Renderer _renderer;

    private bool _isColored = false;

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
        if (collision.collider.TryGetComponent(out Plane plane) && _isColored == false)
        {
            _renderer.material.color = plane.Color;

            _isColored = true;
        }
    }
}
