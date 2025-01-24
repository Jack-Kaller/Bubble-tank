using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomUser : MonoBehaviour
{
    [SerializeField]
    public List<User> users = new List<User>();
    public UnityEvent<int, Vector2, Vector2> onRandomPush;


    void Start()
    {
        users = new List<User>();

        for (int i = 0; i < 10; i++)
        {
            User userTemps = new User();
            userTemps.id = i;

            users.Add(userTemps);
        }
        
    }

    void Update()
    {
        foreach (var user in users)
        {
            onRandomPush.Invoke(user.id, Random.insideUnitCircle , Random.insideUnitCircle);
        }
    }
}
