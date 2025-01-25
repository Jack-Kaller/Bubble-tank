using UnityEngine;
using UnityEngine.Events;

public class TestScript_IntegerToIndexInteger : MonoBehaviour
{

    public int m_playerIndex=42;

    public UnityEvent<int, int> m_onPush;

    public void PushInInteger(int integerValue) { 
    
        m_onPush.Invoke(m_playerIndex, integerValue);
    }
}
