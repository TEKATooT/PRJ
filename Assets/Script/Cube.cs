using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private Color _needColor;

    private const float _fullChance = 100;

    private Rigidbody _rigidBody;
    private Renderer _renderer;
    private float _half = 2;
    private float _disintegrationChance = 100;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = Random.ColorHSV();
    }

    public void GetNewCondition(float disintegrationChance)
    {
        _disintegrationChance = disintegrationChance;

        transform.localScale /= _half;
    }

    private void OnMouseUpAsButton()
    {
        Explode();
    }

    private void Explode()
    {
        if (Random.Range(0f, _fullChance) <= _disintegrationChance)
        {
            Disintegrate();
        }

        Destroy(gameObject);
    }

    private void Disintegrate()
    {
        int minPiecesQuantity = 2;
        int maxPiecesQuantity = 5;

        int piecesQuantity = Random.Range(minPiecesQuantity, maxPiecesQuantity);
        _disintegrationChance = _disintegrationChance / _half;

        for (int i = 0; i < piecesQuantity; i++)
        {
            var newCube = Instantiate(_cubePrefab, transform.position, Quaternion.identity);

            newCube.GetNewCondition(_disintegrationChance);

            newCube.gameObject.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }
}