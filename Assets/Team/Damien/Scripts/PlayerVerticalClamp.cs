using UnityEngine;

public class PlayerVerticalClamp : MonoBehaviour
{
    [SerializeField] private float minY = 0.0f;
    [SerializeField] float maxY = 2.0f;
    [SerializeField] private Transform whatToClamp;
    void Start()
    {
        
    }

    void Update()
    {
        
        Vector3 newVerticalPos = whatToClamp.position;

        if (whatToClamp.position.y < minY)
        {
            newVerticalPos.y = minY + 0.001f;
        }

        if (whatToClamp.position.y > maxY)
        {
            newVerticalPos.y = maxY - 0.001f;
        }
        
        whatToClamp.position = newVerticalPos;
        
    }
}
