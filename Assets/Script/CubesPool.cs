using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Events;
using System.Collections;

public class CubesPool : MonoBehaviour
{
    [SerializeField] private ColoredCube _coloredCube;

    private ObjectPool<ColoredCube> _cubePool;

    private int _minPoolSize = 50;
    private int _maxPoolSize = 100;

    private readonly float _minCubeLifeTime = 2;
    private readonly float _maxCubeLifeTime = 5;

    public event UnityAction Created;
    public event UnityAction<Transform> TurnedOff;

    public float CountActive => _cubePool.CountActive;
    public float CountAll => _cubePool.CountAll;

    private void Awake()
    {
        _cubePool = new ObjectPool<ColoredCube>(() =>
        {
            return Instantiate(_coloredCube);
        }, coloredCube =>
        {
            coloredCube.gameObject.SetActive(true);
        }, coloredCube =>
        {
            coloredCube.gameObject.SetActive(false);
        }, coloredCube =>
        {
            Destroy(coloredCube.gameObject);
        }, false, _minPoolSize, _maxPoolSize);
    }

    public ColoredCube Get()
    {
        ColoredCube newColoredCube = _cubePool.Get();

        Created.Invoke();

        StartCoroutine(Release(newColoredCube));

        return newColoredCube;
    }

    public IEnumerator Release(ColoredCube coloredCube)
    {
        float randomlifeTime = Random.Range(_minCubeLifeTime, _maxCubeLifeTime);

        yield return new WaitForSeconds(randomlifeTime);

        _cubePool.Release(coloredCube);

        TurnedOff.Invoke(coloredCube.transform);
    }
}
