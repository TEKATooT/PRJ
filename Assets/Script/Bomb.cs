using UnityEngine;

[RequireComponent(typeof(Bomb))]
[RequireComponent(typeof(Renderer))]
public class Bomb : MonoBehaviour
{
    [SerializeField] private Material _endMaterial;
    [SerializeField] private Material _startMaterial;

    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private Renderer _renderer;

    private void OnEnable()
    {
        _renderer = GetComponent<Renderer>();

        _renderer.material = _startMaterial;
    }

    private void OnDisable()
    {
        Explode();
    }

    private void Update()
    {
        _renderer.material.Lerp(_renderer.material, _endMaterial, 1 * Time.deltaTime);
    }

    private void Explode()
    {
        Rigidbody cubeRigidbody;

        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider collider in hits)
        {
            if (collider.TryGetComponent(out ColoredCube hittedCube))
            {
                hittedCube.gameObject.TryGetComponent(out cubeRigidbody);

                if (cubeRigidbody != null)
                    cubeRigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }
    }
}
