using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Pools _pool;

    [SerializeField] private Text _allCubes;
    [SerializeField] private Text _activeCubes;

    [SerializeField] private Text _allBombs;
    [SerializeField] private Text _activeBombs;

    private int _total—reatedallCubes = 0;
    private int _total—reatedallBombs = 0;

    private void OnEnable()
    {
        _pool.CubeCreated += AddCubeCount;
        _pool.BombCreated += AddBombCount;
    }

    private void OnDisable()
    {
        _pool.CubeCreated -= AddCubeCount;
        _pool.BombCreated -= AddBombCount;
    }

    private void FixedUpdate()
    {
        _activeCubes.text = ("Active " + _pool.CountCubesActive.ToString());
        _activeBombs.text = ("Active bomb " + _pool.CountBombsActive.ToString());
    }

    private void AddCubeCount()
    {
        _total—reatedallCubes++;

        ShowNewCount();
    }

    private void AddBombCount()
    {
        _total—reatedallBombs++;

        ShowNewCount();
    }

    private void ShowNewCount()
    {
        _allCubes.text = ("For all the time " + _total—reatedallCubes.ToString());
        _allBombs.text = ("For all the time bomb " + _total—reatedallBombs.ToString());
    }
}
