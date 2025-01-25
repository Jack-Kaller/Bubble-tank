using UnityEngine;
using UnityEngine.Events;

public class QuickScript_II2GamepadOrAction : MonoBehaviour
{

    public UnityEvent<int, Vector2, Vector2> m_onGamepadReceived;
    public UnityEvent<int, int> m_onActionEventReceived;
    public int m_lastValueTypeTag =0;
    public STRUCT_ReceivedIID m_lastReceived;
    public STRUCT_GamepadByteId2020Percent11 m_lastGamepad;
    public int m_lastActionReceived= 0;

    public UnityEvent<int> OnServerAction;

    public void PushInIndexInteger(int index, int value) { 
        STRUCT_ReceivedIID received = new STRUCT_ReceivedIID();
        received.index = index;
        received.integer = value;
        received.date = 0;  // Timestamp in seoncds from datetime
        PushInIID(received);
    }


    public void PushInIID(STRUCT_ReceivedIID received) {
        m_lastReceived = received;
        m_lastValueTypeTag = received.integer;

        if(m_lastValueTypeTag <= 100)
        {
            OnServerAction.Invoke(m_lastValueTypeTag);
        }

        int integer = received.integer;
        int twoFirstDigitsLeftToRight = integer / 100000000;
        m_lastValueTypeTag= twoFirstDigitsLeftToRight;
        if (twoFirstDigitsLeftToRight == 18)
        {

            IntegerToGamepad2020Utility.ParseGamepadByteId2020FromInteger(received.integer, out STRUCT_GamepadByteId2020Percent11 gamepad);

            m_lastGamepad = gamepad;
            m_onGamepadReceived.Invoke(
                received.index
                , new Vector3(gamepad.m_joystickLeftHorizontal, gamepad.m_joystickLeftVertical)
                , new Vector3(gamepad.m_joystickRightHorizontal, gamepad.m_joystickRightVertical)
                );
        }
        else { 
            m_onActionEventReceived.Invoke(received.index, received.integer);
            m_lastActionReceived= received.integer;
        }

    }
    
}
