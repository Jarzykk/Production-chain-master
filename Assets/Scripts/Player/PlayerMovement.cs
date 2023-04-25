using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _speed = 3;
    [SerializeField] private ImportantSceneObjects _importantGameObjects;

    private Rigidbody _rigidBody;
    private bool _canMove = true;

    private void OnEnable()
    {
        _importantGameObjects.LevelsTimer.TimerRanOut += DisableMovement;
    }

    private void OnDisable()
    {
        _importantGameObjects.LevelsTimer.TimerRanOut -= DisableMovement;
    }

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_canMove == false)
            return;

        _rigidBody.velocity = new Vector3(_joystick.Horizontal * _speed, _rigidBody.velocity.y, _joystick.Vertical * _speed);

        if(_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidBody.velocity);
        }
    }

    private void DisableMovement()
    {
        _rigidBody.velocity = new Vector3(0, 0, 0);
        _canMove = false;
    }
}
