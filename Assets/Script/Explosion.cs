using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private Separator _separation;

    private const float _fullChance = 100;

    private Cube _cube;

    private void OnEnable()
    {
        _cube = GetComponent<Cube>();

        _cube.Exploded += Explode;
    }

    private void OnDisable()
    {
        _cube.Exploded -= Explode;
    }

    private void Explode(Cube cube)
    {
        if (Random.Range(0f, _fullChance) <= cube.DisintegrationChance)
            _separation.Disintegrate(cube);
        else
            DistributeExplosiveWave(cube);

        Destroy(gameObject);
    }

    private void DistributeExplosiveWave(Cube cube)
    {
        Rigidbody cubeRigidbody;

        Collider[] hits = Physics.OverlapSphere(transform.position, cube.ExplosionRadius);

        foreach (Collider collider in hits)
        {
            if (collider.TryGetComponent(out Cube hittedCube))
            {
                cubeRigidbody = null;

                float cubeDistance = Vector3.Distance(transform.position, hittedCube.transform.position);

                if (cubeDistance != 0)
                    hittedCube.gameObject.TryGetComponent(out cubeRigidbody);

                if (cubeRigidbody != null)
                    cubeRigidbody.AddExplosionForce(cube.ExplosionForce * cube.Iteration / cubeDistance, transform.position, cube.ExplosionRadius * cube.Iteration);
            }
        }
    }
}
