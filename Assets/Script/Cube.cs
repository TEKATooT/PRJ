using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private Color _needColor;

    private const float _half = 2;
    private const float _fullChance = 100;

    private Rigidbody _rigidBody;
    private Renderer _renderer;
    private float _disintegrationChance = 100;
    private float _iteration = 1;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = Random.ColorHSV();
    }

    public void GetNewCondition(float disintegrationChance, float iteration)
    {
        _disintegrationChance = disintegrationChance;
        _iteration = iteration;

        _iteration++;
        transform.localScale /= _half;
    }

    private void OnMouseUpAsButton()
    {
        Explode();
    }

    private void Explode()
    {
        if (Random.Range(0f, _fullChance) <= _disintegrationChance)
            Disintegrate();
        else
            ExplosiveWave();

        Destroy(gameObject);
    }

    private void ExplosiveWave()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider collider in hits)
        {
            if (collider.TryGetComponent(out Cube cube))
            {
                Vector3 gameObjectPosition = new Vector3(transform.position.z, transform.position.y, transform.position.z);
                Vector3 cubePosition = new Vector3(cube.transform.position.z, cube.transform.position.y, cube.transform.position.z);

                float cubeDistance = Vector3.Distance(gameObjectPosition, cubePosition);

                if (cubeDistance != 0)
                    cube.gameObject.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce * _iteration / cubeDistance, transform.position, _explosionRadius * _iteration);
            }
        }
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

            newCube.GetNewCondition(_disintegrationChance, _iteration);
        }
    }
}