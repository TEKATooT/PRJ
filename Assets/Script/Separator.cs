using UnityEngine;

public class Separator : MonoBehaviour
{
    private const float _half = 2;

    [SerializeField] private Cube _cubePrefab;

    public void Disintegrate(Cube cube)
    {
        int minPiecesQuantity = 2;
        int maxPiecesQuantity = 5;

        int piecesQuantity = Random.Range(minPiecesQuantity, maxPiecesQuantity);
        float disintegrationChance = cube.DisintegrationChance / _half;
        float iteration = cube.Iteration / _half;

        iteration++;

        for (int i = 0; i < piecesQuantity; i++)
        {
            var newCube = Instantiate(_cubePrefab, cube.transform.position, Quaternion.identity);

            newCube.GetNewCondition(disintegrationChance, iteration);
        }
    }
}
