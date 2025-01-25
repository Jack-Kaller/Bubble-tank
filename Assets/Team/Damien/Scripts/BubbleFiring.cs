using UnityEngine;
using UnityEngine.Assertions;

public class BubbleFiring : MonoBehaviour
{

    [Header("Bubble stats")] 
    [SerializeField] float speed = 2.0f;
    
    [SerializeField] GameObject bubbleSpawner;
    [SerializeField] GameObject bubblePrefab;
    [SerializeField] float waitTimeBeforeShoot = 1;
    public int actionTriggered;

    private bool _isReloading = false;
    private float _timer;
    void Start()
    {
        Assert.IsNotNull(bubbleSpawner);
        Assert.IsNotNull(bubblePrefab);

        _timer = waitTimeBeforeShoot;
    }

    public void onAction(int action)
    {
        actionTriggered = action;   
    }

    void Update()
    {
        if (_isReloading && _timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        
        if (actionTriggered != 0 && !isBubbleOnReload())
        {
            if (actionTriggered.ToString().StartsWith("13") )
            {
                GameObject bubble = Instantiate(bubblePrefab, bubbleSpawner.transform.position, Quaternion.identity);
                bubble.GetComponent<Rigidbody>().AddForce(bubbleSpawner.transform.forward * speed);
                _timer = waitTimeBeforeShoot;
                _isReloading = true;
            }
        }

        actionTriggered = 0;
    }

    bool isBubbleOnReload() 
    {
        if (_timer > 0 && _isReloading)
        {
            _isReloading = true;
        }
        else
        {
            _isReloading = false;
        }
        
        return _isReloading;
    }
}
