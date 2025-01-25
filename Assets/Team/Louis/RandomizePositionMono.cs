using UnityEngine;

public class RandomizePositionMono : MonoBehaviour
{
    // Define a range for randomizing positions
    public Vector3 minPosition = new Vector3(-10f, 0, -10f);
    public Vector3 maxPosition = new Vector3(10f, 0, 10f);

    /// <summary>
    /// Randomizes the position of the cube.
    /// This function can be called from the Unity Inspector.
    /// </summary>
    [ContextMenu("Randomize Position")]
    public void RandomizePosition()
    {
        float randomX = Random.Range(minPosition.x, maxPosition.x);
        float randomY = Random.Range(minPosition.y, maxPosition.y);
        float randomZ = Random.Range(minPosition.z, maxPosition.z);

        transform.position = new Vector3(randomX, randomY, randomZ);
        Debug.Log($"New Position: {transform.position}");
    }
}
