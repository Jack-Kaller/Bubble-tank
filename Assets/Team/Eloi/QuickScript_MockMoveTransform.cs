using UnityEngine;

public class QuickScript_MockMoveTransform :MonoBehaviour {

    public Transform m_whatToMove;
    public float m_speed;

    public Vector2 m_joystickMove;
    

    

    public void SetJoystick(Vector2 joystick)
    {
        m_joystickMove = joystick;
    }

    public void Update()
    {
        m_whatToMove.position += new Vector3(m_joystickMove.x, 0, m_joystickMove.y) * m_speed * Time.deltaTime;
        
    }
}
