using UnityEngine;

public class CarouselsManagement : MonoBehaviour
{
    [SerializeField] private Swing _swing;
    [SerializeField] private Catapult _catapult;
    [SerializeField] private CubesSpawner _spawner;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _swing.StartPump();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _catapult.Launch();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            _catapult.Reload();
            _spawner.CubeSpawn();
        }
    }
}