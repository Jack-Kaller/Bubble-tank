using System.Collections.Generic;
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

    [SerializeField]
    private TextMeshProUGUI textAllUserDead;

    public bool isGameStarted = false;

    [SerializeField]
    private List<GameObject> activeUsers;

    public AllUserDoubleJoystick userDb;

    public bool isGood = true;


    void Update()
    {
        if (isGameStarted)
        {
            if (isGood)
            {
                activeUsers = new List<GameObject>(userDb.allUsersGameObject);
                isGood= false;
            }
            m_Time += Time.deltaTime;

            System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(m_Time);
            m_TextMeshProUGUI.text = timeSpan.ToString(@"mm\:ss");

            if (timeSpan.TotalMinutes >= 5) 
            {
                Debug.Log("Temps écoulé, réinitialisation du jeu.");
                foreach (GameObject gameObject in activeUsers)
                {
                    if (!gameObject.activeInHierarchy)
                    {
                        Debug.Log($"{gameObject.name} est inactif et sera ignoré.");
                    }
                }
                factory.ResetGame();
            }


            for (int i = activeUsers.Count - 1; i >= 0; i--) 
            {
                if (!activeUsers[i].activeInHierarchy)
                {
                    Debug.Log($"Utilisateur {activeUsers[i].name} est désactivé et sera retiré.");
                    activeUsers.RemoveAt(i);

                    PlayerTeamIdRelayMono PTIRM = activeUsers[i].GetComponentInChildren<PlayerTeamIdRelayMono>();
                    int idOfUser = PTIRM.GetTeamId();

                    textAllUserDead.text += $"user {idOfUser}\r\n" ;
                }
            }

        }
        else
        {
            m_Time = 0;
        }
    }

}
