using UnityEngine;

[System.Serializable]
public class User
{
    [SerializeField]
    public int id;

    public int user
    {
        get { return id; }
        set { id = value; }
    }


}