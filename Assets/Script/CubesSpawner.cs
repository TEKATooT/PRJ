using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] private ObjectsPool _pool;
    [SerializeField] private Transform[] _spawenPoints;

    private WaitForSeconds _second = new WaitForSeconds(1);

    private void Start()
    {
        StartCoroutine(Generate());
    }

    private Vector3 GetPosition()
    {
        int randomPosition = Random.Range(0, _spawenPoints.Length);

        return _spawenPoints[randomPosition].position;
    }

    private IEnumerator Generate()
    {
        while (true)
        {
            ColoredCube newColoredCube = _pool.Get();

            newColoredCube.transform.position = GetPosition();

            yield return _second;
        }
    }
}
