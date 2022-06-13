using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BasePlayerController
{
    [SerializeField]
    CharacterController _characterController;
    [SerializeField]
    Transform _camera;
    [SerializeField]
    float speed;
    float horizontalInput;
    float verticalInput;

    float turnSoothTime = 0.1f;
    float turnSoomthVelocity;
    void Start()
    {

    }
    private void FixedUpdate()
    {
        MovePlayer();
        //  Debug.Log(GameController.instance.FindPlayerNear(transform)[1]);
        //  PlayerLookAt();
    }
    void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        // -5.43071
        Debug.Log(horizontalInput);
        Debug.Log(verticalInput);
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (direction.magnitude >= 0.1f)
        {
            AnimationIdleToRun();
            //  float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
            //  float angle = Mathf.SmoothDampAngle(transform.localEulerAngles.y, targetAngle, ref turnSoomthVelocity, turnSoothTime);

            // transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //   _characterController.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else
        {
            AnimationRunToIdle();
            if (Input.GetKeyDown("space"))
            {
                AnimationIdleToShoot();
                Shooting();
            }
            if (Input.GetKeyUp("space"))
            {
                AnimationShootToIdle();

            }
        }
    }

}
