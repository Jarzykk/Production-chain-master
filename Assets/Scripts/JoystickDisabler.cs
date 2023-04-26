using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FixedJoystick))]
public class JoystickDisabler : MonoBehaviour
{
    [SerializeField] private ImportantSceneObjects _importantObjects;

    private FixedJoystick _joystick;

    private void OnEnable()
    {
        _importantObjects.SceneUI.ScreenEnabled += DisableJoystick;
    }

    private void OnDisable()
    {
        _importantObjects.SceneUI.ScreenEnabled -= DisableJoystick;
    }

    private void Start()
    {
        _joystick = GetComponent<FixedJoystick>();
    }

    private void DisableJoystick()
    {
        _joystick.enabled = false;
    }
}
