using System;
using UnityEngine;

public class BubbleDestructor : MonoBehaviour
{

    [SerializeField] float lifetime = 2.0f;

    private float _timer;
    void Start()
    {
        _timer = lifetime;
    }

    void Update()
    {
        if (_timer <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            _timer -= Time.deltaTime;    
        }
    }

    private void OnCollisionEnter(Collision bubbleCollider)
    {
        if (bubbleCollider.gameObject.CompareTag("bubble"))
        {
            Destroy(gameObject);
        }
    }
}
