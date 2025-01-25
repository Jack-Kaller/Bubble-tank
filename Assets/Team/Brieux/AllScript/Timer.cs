using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_TextMeshProUGUI;
    private float m_Time = 0;

    [SerializeField]
    private AllUserDoubleJoystick factory;

    public bool isGameStarted = false;

    void Update()
    {
        if (isGameStarted)
        {
            m_Time += Time.deltaTime;

            int seconde = (int) m_Time % 60;
            int minute = (int) m_Time / 60;

            string formatted = $"{seconde:D2}";

            m_TextMeshProUGUI.text = $"{minute}:{formatted}";

            if(minute >= 1)
            {
                factory.PauseGame();
            }

        }
        else
        {
            m_Time = 0;
        }
    }

}
