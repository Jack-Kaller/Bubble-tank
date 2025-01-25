using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AllUserDoubleJoystick : MonoBehaviour
{
    public List<UserIdToDoubleJoyStick> allUser;
    public List<Team> allTeam;
    public List<User> users;
    public UnityEvent<UserIdToDoubleJoyStick> onValueChanged;
    public UnityEvent<UserIdToDoubleJoyStick> onNewUser;
    public GameObject prefabUser;
    public TextMeshProUGUI textAllUserConnected;
    public Canvas canvasMenu;

    public void SetOrAdd(int userId , Vector2 joystickLeft, Vector2 joystickRight)
    {
        for (int i = 0; i < allUser.Count; i++)
        {
            if (allUser[i].id == userId)
            {
                allUser[i].joystickLeft = joystickLeft;
                allUser[i].joystickRight = joystickRight;
                onValueChanged.Invoke(allUser[i]);
                return;
            }
        }
        UserIdToDoubleJoyStick newUser = new UserIdToDoubleJoyStick { id = userId, joystickLeft = joystickLeft, joystickRight = joystickRight };
        allUser.Add(newUser);
        onNewUser.Invoke(newUser);
        onValueChanged.Invoke(newUser);
        User tempUser = new User();
        tempUser.id = userId;
        users.Add( tempUser);
        textAllUserConnected.text += $"user avec id : {userId}\r\n"; 
    }


    public void LaunchGame()
    {
        if (CreateTeam())
        {
            Vector3[] teamPositions = {
                new Vector3(-50, 10, 0), 
                new Vector3(20, 10, 0), 
                new Vector3(-20, 10, 0),
                new Vector3(0, -10, 0)  
            };
            Color[] teamColors = {
                Color.red,
                Color.blue,
                Color.green,
                Color.black
            };

            canvasMenu.enabled = false;
            for (int teamIndex = 0; teamIndex < allTeam.Count; teamIndex++)
            {
                Team team = allTeam[teamIndex];

                for (int i = 0; i < team.User.Count; i++)
                {
                    GameObject test = Instantiate(prefabUser);
                    test.name = $"Utilisateur_{team.User[i].id}";

                    PlayerTeamIdRelayMono idOfPlayer = test.gameObject.GetComponent<PlayerTeamIdRelayMono>();
                    PlayerColorRelayMono colorPlayer = test.GetComponent<PlayerColorRelayMono>();
                    PlayerGamepadRelayMono gamepadPlayer = test.GetComponent<PlayerGamepadRelayMono>();

                    idOfPlayer.SetTeamId(team.User[i].id);
                    colorPlayer.SetColor(teamColors[teamIndex]);
                    gamepadPlayer.PushInGamepadValue(team.User[i].id, Random.insideUnitCircle, Random.insideUnitCircle);

                    Vector3 offset = new Vector3(i * 1, 0, 0);
                    test.transform.position = teamPositions[teamIndex] + offset;

                    Renderer renderer = test.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        renderer.material.color = teamColors[teamIndex];
                    }

                    Debug.Log($"Utilisateur {team.User[i].id} positionné en {test.transform.position}");
                }
            }
        }
        else
        {
            Debug.LogError("Probleme.");
        }
    }

    public bool CreateTeam()
    {
        int sizeUser = users.Count;
        allTeam = new List<Team>();

        if (sizeUser < 4)
        {
            Debug.LogError("Il n'y a pas assez de personnes pour créer une équipe.");
            return false;
        }

        int numberOfTeams;
        if (sizeUser < 9)
        {
            Debug.Log("Création de 2 équipes.");
            numberOfTeams = 2;
        }
        else if (sizeUser < 15)
        {
            Debug.Log("Création de 3 équipes.");
            numberOfTeams = 3;
        }
        else if (sizeUser <= 20)
        {
            Debug.Log("Création de 4 équipes.");
            numberOfTeams = 4;
        }
        else
        {
            Debug.LogError("Vous avez trop de personnes.");
            return false;
        }

        for (int i = 0; i < numberOfTeams; i++)
        {
            allTeam.Add(new Team { User = new List<User>() });
        }

        for (int i = 0; i < sizeUser; i++)
        {
            int teamIndex = i % numberOfTeams;
            allTeam[teamIndex].User.Add(users[i]);
        }
        return true;
    }

}


[System.Serializable]
public class RelayDoubleGamepadEvent : UnityEvent<int, Vector2, Vector2> { }
