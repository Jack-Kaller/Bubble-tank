using System.Collections.Generic;
using UnityEngine;

public class A_GetAllUser : MonoBehaviour
{
    [SerializeField]
    public List<User> allUser;
    public List<Team> allTeam;

    void Start()
    {
    }

    void GetAllUser(List<User> users)
    {
        allUser = users;
    }

    void AddUser(User user)
    {
        allUser.Add(user);
    }

    public void CreateTeam()
    {
        int sizeUser = allUser.Count;
        allTeam = new List<Team>();

        if (sizeUser < 4)
        {
            Debug.LogError("Il n'y a pas assez de personnes pour créer une équipe.");
            return;
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
            return;
        }

        for (int i = 0; i < numberOfTeams; i++)
        {
            allTeam.Add(new Team { User = new List<User>() });
        }

        for (int i = 0; i < sizeUser; i++)
        {
            int teamIndex = i % numberOfTeams;
            allTeam[teamIndex].User.Add(allUser[i]);
        }
    }


}
