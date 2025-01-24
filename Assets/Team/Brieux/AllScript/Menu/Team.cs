using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Team
{
    [SerializeField]
    public List<User> User { get; set; }

}