using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _speed = 3;

    private Rigidbody _rigidBody;
    private bool _canMove = true;

    private void OnEnable()
    {
        GetComponent<Player>().ImportantSceneObjects.LevelsTimer.TimerRanOut += DisableMovement;
    }

    private void OnDisable()
    {
        GetComponent<Player>().ImportantSceneObjects.LevelsTimer.TimerRanOut -= DisableMovement;
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
