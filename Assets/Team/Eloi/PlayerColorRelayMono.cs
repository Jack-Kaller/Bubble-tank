using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerColorRelayMono : MonoBehaviour
{

    public Color m_playerColor;
    public UnityEvent<Color> m_onColorChanged;

    public void SetColor(Color color)
    {
        m_playerColor = color;
        m_onColorChanged.Invoke(m_playerColor);
    }

    [ContextMenu("Push Color")]
    public void PushColorInInspector()
    {
        SetColor(m_playerColor);
    }
}
