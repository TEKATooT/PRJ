using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private CubesPool _cubePool;
    [SerializeField] private BombsPool _bombPool;

    [SerializeField] private Text _allCubes;
    [SerializeField] private Text _activeCubes;
    private int _total—reatedallCubes = 0;

    [SerializeField] private Text _allBombs;
    [SerializeField] private Text _activeBombs;
    private int _total—reatedallBombs = 0;

    private void OnEnable()
    {
        _cubePool.Created += AddCubeCount;
        _bombPool.Created += AddBombCount;
    }

    private void OnDisable()
    {
        _cubePool.Created -= AddCubeCount;
        _bombPool.Created -= AddBombCount;
    }

    private void FixedUpdate()
    {
        _activeCubes.text = ("Active " + _cubePool.CountActive.ToString());
        _activeBombs.text = ("Active bomb " + _bombPool.CountActive.ToString());
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
