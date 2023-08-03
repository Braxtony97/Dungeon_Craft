using UnityEngine;

public class SetActiveJoystick : MonoBehaviour
{
    public void JoystickSetActive(bool Active)
    {
        if (Active == true) gameObject.SetActive(Active);
        else if (Active == false) gameObject.SetActive(Active);
    }
}
