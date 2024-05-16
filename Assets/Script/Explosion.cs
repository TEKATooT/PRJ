using UnityEngine;

public class Explosion : MonoBehaviour
{
    private const float _fullChance = 100;

    [SerializeField] private Separation _separation;

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
        Collider[] hits = Physics.OverlapSphere(transform.position, cube.ExplosionRadius);

        foreach (Collider collider in hits)
        {
            if (collider.TryGetComponent(out Cube hittedCube))
            {
                float cubeDistance = Vector3.Distance(transform.position, hittedCube.transform.position);

                if (cubeDistance != 0)
                    hittedCube.gameObject.GetComponent<Rigidbody>().AddExplosionForce(cube.ExplosionForce * cube.Iteration / cubeDistance, transform.position, cube.ExplosionRadius * cube.Iteration);
            }
        }
    }
}
