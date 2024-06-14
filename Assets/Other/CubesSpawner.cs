using UnityEngine;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    public void CubeSpawn()
    {
        Instantiate(_cube, transform.position, Quaternion.identity);
    }
}