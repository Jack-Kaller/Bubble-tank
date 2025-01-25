using UnityEngine;

public class QuickScript_MockMoveRigidBody : MonoBehaviour
{
    public Rigidbody m_whatToMove;
    public float m_moveForce=2;
    public ForceMode m_forceMode = ForceMode.Impulse;

    public Vector2 m_joystickMove;

    public void SetJoystick(Vector2 joystick)
    {
        m_joystickMove = joystick;
    }

    public void Update()
    {
        Vector3 direction = new Vector3(m_joystickMove.x, 0, m_joystickMove.y);
        m_whatToMove.AddForce(direction * m_moveForce, m_forceMode);

    }
}
