using UnityEngine;

public class PlayerDestructor : MonoBehaviour
{
    
    [SerializeField] int lifePoints = 3;
    
    private void OnCollisionEnter(Collision bubble)
    {
        
        Rigidbody rbdy = gameObject.GetComponent<Rigidbody>();

        //Stop Moving/Translating
        rbdy.linearVelocity = Vector3.zero;

        //Stop rotating
        rbdy.angularVelocity = Vector3.zero;
        
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
