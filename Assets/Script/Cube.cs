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

    public void GetDisintegrationChance(float disintegrationChance)
    {
        _disintegrationChance = disintegrationChance;
    }

    private void OnMouseUpAsButton()
    {
        Explosion();
    }

    private void Explosion()
    {
        if (Random.Range(0f, _fullChance) <= _disintegrationChance)
        {
            Disintegration();
        }

        ExplosionWave();
        Destroy(gameObject);
    }

    private void ExplosionWave()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider collider in hits)
        {
            if (collider.TryGetComponent(out Cube cube))
            {
                cube.gameObject.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }
    }

    private void Disintegration()
    {
        int minPiecesQuantity = 2;
        int maxPiecesQuantity = 5;

        int piecesQuantity = Random.Range(minPiecesQuantity, maxPiecesQuantity);
        _disintegrationChance = _disintegrationChance / _half;

        for (int i = 0; i < piecesQuantity; i++)
        {
            var newCube = Instantiate(_cubePrefab, transform.position, Quaternion.identity);

            Vector3 newScale = newCube.gameObject.transform.localScale /= _half;

            newCube.gameObject.transform.localScale = newScale;

            newCube.GetDisintegrationChance(_disintegrationChance);
        }
    }
}