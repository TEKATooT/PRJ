using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    private const float _half = 2;

    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Color _needColor;

    private Renderer _renderer;

    private float _iteration = 1;
    private float _explosionForce = 500;
    private float _explosionRadius = 25;
    private float _disintegrationChance = 100;

    public event UnityAction<Cube> Exploded;

    public float Iteration => _iteration;
    public float ExplosionForce => _explosionForce;
    public float ExplosionRadius => _explosionRadius;
    public float DisintegrationChance => _disintegrationChance;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = Random.ColorHSV();
    }

    public void GetNewCondition(float disintegrationChance, float iteration)
    {
        _disintegrationChance = disintegrationChance;
        _iteration = iteration;

        transform.localScale /= _half;
    }

    private void OnMouseUpAsButton()
    {
        Exploded.Invoke(this);
    }
}