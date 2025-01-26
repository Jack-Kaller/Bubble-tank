using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    [Header("Player stats")]
    [SerializeField] float moveForce = 2;
    [SerializeField] float rotationSpeedAngle = 2;
    [SerializeField] Rigidbody rigidbody;

    [SerializeField] private Transform m_direction;
    public Vector2 leftJoystick;
    public Vector2 rightJoystick;
    public ForceMode mode = ForceMode.Impulse;

    public float m_transformMoveForwardSpeed = 1; 

        public bool m_useRigid=false;
    public bool m_useTransform = true;
    
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
        if (m_useRigid) { 
            float horizontal = leftJoystick.x;
            float vertical = leftJoystick.y;

            Vector3 direction = m_direction.forward;
            direction.y = 0;
        
            rigidbody.AddForce(direction * (moveForce * vertical* Time.deltaTime), mode);
        }

        if (m_useTransform) {


            Vector3 direction = m_direction.forward;
            direction.y = 0;

            rigidbody.transform.position += direction * (leftJoystick.y * Time.deltaTime* m_transformMoveForwardSpeed);
        }

    }

    void Rotate()
    {
        float horizontal = leftJoystick.x;
        rigidbody.transform.Rotate(new Vector3(0, (horizontal ) * Time.deltaTime * rotationSpeedAngle, 0));
    }
}