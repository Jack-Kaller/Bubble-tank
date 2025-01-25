using UnityEngine;
using UnityEngine.Events;

public  class PlayerInputRelayMono : MonoBehaviour {

    public int m_userIntegerId;
    public Vector3 m_joystickLeftPercent;
    public Vector3 m_joystickRightPercent;
    public RelayDoubleGamepadEvent m_onGamepadReceived;
    public UnityEvent<int> m_onActionEventReceived;
    public UnityEvent<int, int> m_onActionEventWithIdReceived;

    public void PushInGamepadValue(int userIntegerId, Vector2 joystickLeftPercent, Vector2 joystickRightPercent)
    {
        m_userIntegerId = userIntegerId;
        m_joystickLeftPercent = joystickLeftPercent;
        m_joystickRightPercent = joystickRightPercent;
        m_onGamepadReceived.Invoke(userIntegerId, joystickLeftPercent, joystickRightPercent);
    }

    public void PushInIntegerAction(int userIntegerId, int integerEvent) {
        m_userIntegerId = userIntegerId;
        m_onActionEventReceived.Invoke(integerEvent);
        m_onActionEventWithIdReceived.Invoke(userIntegerId, integerEvent);
    }
}