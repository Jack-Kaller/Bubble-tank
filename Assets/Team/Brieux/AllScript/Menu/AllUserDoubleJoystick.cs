using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AllUserDoubleJoystick : MonoBehaviour
{
    public List<UserIdToDoubleJoyStick> allUser;
    public UnityEvent<UserIdToDoubleJoyStick> onValueChanged;
    public UnityEvent<UserIdToDoubleJoyStick> onNewUser;


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

    }
}


[System.Serializable]
public class RelayDoubleGamepadEvent : UnityEvent<int, Vector2, Vector2> { }
