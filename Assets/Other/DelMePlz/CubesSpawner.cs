using System.Collections;
using UnityEngine;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] private ObjectsPool _pool;
    [SerializeField] private Transform[] _spawenPoints;

    private readonly float _minCubeLifeTime = 2;
    private readonly float _maxCubeLifeTime = 5;

    private ColoredCube _newColoredCube;
    private WaitForSeconds _second = new WaitForSeconds(1);

    private void Start()
    {
        StartCoroutine(Generate());
    }

    private Transform GetPosition()
    {
        int position = Random.Range(0, _spawenPoints.Length);

        return _spawenPoints[position];
    }

    private IEnumerator Generate()
    {
        while (true)
        {
            Transform newPosition = GetPosition();

            _newColoredCube = _pool.Get(newPosition.position);

            float randomLifeTime = Random.Range(_minCubeLifeTime, _maxCubeLifeTime);
            
            //Invoke(nameof(Release), randomLifeTime);

            yield return _second;
        }
    }

    private void Release()
    {
        _pool.Release(_newColoredCube);
    }
}
