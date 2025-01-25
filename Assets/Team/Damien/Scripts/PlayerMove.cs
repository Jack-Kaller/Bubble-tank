using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMove : MonoBehaviour
{
    
    [SerializeField] float moveForce = 2;
    [SerializeField] float rotationSpeed = 2;
    [SerializeField] Rigidbody rb;
    
    public Vector2 leftJoystick;
    public Vector2 rightJoystick;
    public ForceMode mode = ForceMode.Impulse;
    
    public void PushIn(Vector2 leftJoystick, Vector2 rightJoystick)
    {
        this.leftJoystick = leftJoystick;
        this.rightJoystick = rightJoystick;
    }

    void Update()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        float horizontal = leftJoystick.x;
        float vertical = leftJoystick.y;
        
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        rb.AddForce(direction * moveForce, mode);
    }

    void Rotate()
    {
        float horizontal = rightJoystick.x;
        float vertical = rightJoystick.y;
        rb.transform.Rotate(new Vector3(0, (horizontal + vertical) * Time.deltaTime * rotationSpeed, 0));
    }
}