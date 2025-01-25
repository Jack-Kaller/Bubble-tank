using UnityEngine;
using UnityEngine.Events;

public class QuickScript_SplitDoubleJoystickToVector2 : MonoBehaviour
{

    public UnityEvent<Vector2> m_onLeft;
    public UnityEvent<Vector2> m_onRight;

    public void PushIn(Vector2 left, Vector2 right)
    {
        m_onLeft.Invoke(left);
        m_onRight.Invoke(right);
    }
    public void PushIn(int playerId, Vector2 left, Vector2 right)
    {
        m_onLeft.Invoke(left);
        m_onRight.Invoke(right);
    }
}
