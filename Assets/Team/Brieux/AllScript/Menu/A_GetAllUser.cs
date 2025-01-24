using System.Collections.Generic;
using UnityEngine;

public class A_GetAllUser : MonoBehaviour
{
    [SerializeField]
    public List<User> allUser;
    public List<Team> allTeam;

    void Start()
    {
        allUser= new List<User>();

        for (int i = 0; i < 10; i++)
        {   
            User userTemps = new User();
            userTemps.id = i;

            allUser.Add(userTemps);
        }

        System.Threading.Thread.Sleep(1000);

        allTeam = createTeam();

    }


    void addUser(User user)
    {
        allUser.Add(user);
    }


    public List<Team> createTeam()
    {
        int sizeUser = allUser.Count;
        List<Team> listTeam = new List<Team>();

        if (sizeUser < 4)
        {
            Debug.LogError("Il n'y a pas assez de personnes pour créer une équipe.");
            return null;
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
            return null;
        }

        for (int i = 0; i < numberOfTeams; i++)
        {
            listTeam.Add(new Team { User = new List<User>() });
        }

        for (int i = 0; i < sizeUser; i++)
        {
            int teamIndex = i % numberOfTeams;
            listTeam[teamIndex].User.Add(allUser[i]);
        }

        return listTeam;
    }



}
