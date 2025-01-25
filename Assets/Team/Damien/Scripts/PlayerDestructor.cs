using UnityEngine;

public class PlayerDestructor : MonoBehaviour
{
    
    [SerializeField] int lifePoints = 3;
    
    private void OnCollisionEnter(Collision otherCollider)
    {
        
        Rigidbody rbdy = gameObject.GetComponent<Rigidbody>();
        rbdy.linearVelocity = Vector3.zero;
        rbdy.angularVelocity = Vector3.zero;
        
        if (otherCollider.gameObject.CompareTag("bubble"))
        {
            Destroy(otherCollider.gameObject);
            lifePoints--;
            if (lifePoints == 0)
            {
                gameObject.SetActive(false);
            }
        }

        
    }
}
