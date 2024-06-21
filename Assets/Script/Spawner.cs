using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Pools _pools;
    [SerializeField] private Transform[] _spawenPoints;

    private WaitForSeconds _second = new WaitForSeconds(1);

    private void OnEnable()
    {
        _pools.TurnedOff += CreateBomb;
    }

    private void Start()
    {
        StartCoroutine(Generate());
    }

    private void OnDisable()
    {
        _pools.TurnedOff -= CreateBomb;
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
            ColoredCube newColoredCube = _pools.GetCube();

            newColoredCube.transform.position = GetPosition();

            yield return _second;
        }
    }

    private void CreateBomb(Transform transform)
    {
        Bomb bomb = _pools.GetBomb();

        bomb.transform.position = transform.position;
    }
}
