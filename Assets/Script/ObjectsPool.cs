using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private ColoredCube _coloredCube;

    private ObjectPool<ColoredCube> _pool;

    private int _minPoolSize = 50;
    private int _maxPoolSize = 100;

    private void Awake()
    {
        _pool = new ObjectPool<ColoredCube>(() =>
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

    public ColoredCube Get(Vector3 transform)
    {
        ColoredCube newColoredCube = _pool.Get();
        
        newColoredCube.transform.position = transform;

        return newColoredCube;
    }

    public void Release(ColoredCube coloredCube)
    {
        _pool.Release(coloredCube);
    }
}
