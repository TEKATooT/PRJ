using System.Collections;
using UnityEngine;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] private ObjectsPool _pool;
    [SerializeField] private Transform[] _spawenPoints;
    [SerializeField] private CubeLifeCycle _cubeLifeCycle;

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

            ColoredCube newColoredCube = _pool.Get(newPosition.position);

            _cubeLifeCycle.TakeCube(newColoredCube);

            yield return _second;
        }
    }
}
