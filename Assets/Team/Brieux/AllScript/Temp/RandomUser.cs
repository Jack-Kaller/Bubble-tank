using System.Collections;
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
            userTemps.id = Random.Range(-2_000_000, 2_000_000);

            users.Add(userTemps);
        }

        StartCoroutine(UpdateUsersCoroutine());
    }

    void Update()
    {
        /*foreach (var user in users)
        {
            onRandomPush.Invoke(user.id, Random.insideUnitCircle , Random.insideUnitCircle);
        }*/
    }

    IEnumerator UpdateUsersCoroutine()
    {
        while (true) 
        {
            foreach (var user in users)
            {
                onRandomPush.Invoke(user.id, Random.insideUnitCircle, Random.insideUnitCircle);
                yield return new WaitForSeconds(1); 
            }
        }
    }
}
