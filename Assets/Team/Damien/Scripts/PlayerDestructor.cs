using UnityEngine;

public class PlayerDestructor : MonoBehaviour
{
    
    [SerializeField] int lifePoints = 3;
    
    private void OnCollisionEnter(Collision bubble)
    {
        if (bubble.gameObject.CompareTag("bubble"))
        {
            Destroy(bubble.gameObject);
            lifePoints--;
            if (lifePoints == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
