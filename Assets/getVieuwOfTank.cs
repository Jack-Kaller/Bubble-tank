using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getVieuwOfTank : MonoBehaviour
{
    public GameObject[] allUser;
    public Transform cameraTransform;
    private GameObject user = null;

    void Start()
    {
        StartCoroutine(cameraVieuw());
    }


    IEnumerator cameraVieuw()
    {
        yield return new WaitForSeconds(5);

        allUser = GameObject.FindGameObjectsWithTag("Player");


        while (user == null || !user.activeInHierarchy)
        {
            int random = Random.Range(0, allUser.Length);

            user = allUser[random];
        }
               

    }

    private void Update()
    {
        cameraTransform = user.transform;
    }
}
