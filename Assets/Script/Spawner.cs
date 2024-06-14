using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CubesPool _cubePool;
    [SerializeField] private BombsPool _bombPool;
    [SerializeField] private Transform[] _spawenPoints;

    private WaitForSeconds _second = new WaitForSeconds(1);

    private void OnEnable()
    {
        _cubePool.TurnedOff += CreateBomb;
    }

    private void Start()
    {
        StartCoroutine(Generate());
    }

    private void OnDisable()
    {
        _cubePool.TurnedOff -= CreateBomb;
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
            ColoredCube newColoredCube = _cubePool.Get();

            newColoredCube.transform.position = GetPosition();

            yield return _second;
        }
    }

    private void CreateBomb(Transform transform)
    {
        Bomb bomb = _bombPool.Get();

        bomb.transform.position = transform.position;
    }
}
