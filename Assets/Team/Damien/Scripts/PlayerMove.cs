using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    [Header("Player stats")]
    [SerializeField] float moveForce = 2;
    [SerializeField] float rotationSpeed = 2;
    [SerializeField] Rigidbody rb;

    [SerializeField] private Transform m_direction;
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

        Vector3 direction = m_direction.forward;
        direction.y = 0;
        
        rb.AddForce(direction * (moveForce * vertical), mode);

        Vector3 directionRight = m_direction.right;
        direction.y = 0;
        
        rb.AddForce(directionRight * (moveForce * horizontal), mode);
    }

    void Rotate()
    {
        float horizontal = rightJoystick.x;
        float vertical = rightJoystick.y;
        rb.transform.Rotate(new Vector3(0, (horizontal + vertical) * Time.deltaTime * rotationSpeed, 0));
    }
}