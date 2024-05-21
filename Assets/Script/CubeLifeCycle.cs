using System.Collections;
using UnityEngine;

public class CubeLifeCycle : MonoBehaviour
{
    [SerializeField] private ObjectsPool _pool;

    private readonly float _minCubeLifeTime = 2;
    private readonly float _maxCubeLifeTime = 5;

    public void TakeCube(ColoredCube coloredCube)
    {
        coloredCube.Ñolored += SetTimeRealease;
    }

    private void SetTimeRealease(ColoredCube coloredCube)
    {
        float randomLifeTime = Random.Range(_minCubeLifeTime, _maxCubeLifeTime);

        StartCoroutine(Release(coloredCube, randomLifeTime));

        coloredCube.Ñolored -= SetTimeRealease;
    }

    private IEnumerator Release(ColoredCube coloredCube, float randomLifeTime)
    {
        WaitForSeconds seconds = new WaitForSeconds(randomLifeTime);

        yield return seconds;

        _pool.Release(coloredCube);
    }
}
