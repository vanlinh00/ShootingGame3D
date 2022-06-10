using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BasePlayerController
{
    [SerializeField]
    CharacterController _characterController;

    [SerializeField]
    float speed;
    float horizontalInput;
    float verticalInput;
    void Start()
    {

    }
    private void FixedUpdate()
    {
        MovePlayer();
        //  Debug.Log(GameController.instance.FindPlayerNear(transform)[1]);
        PlayerLookAt();
    }
    void MovePlayer()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        Debug.Log(horizontalInput);
        Debug.Log(verticalInput);
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        if (direction.magnitude >= 0.1f)
        {
            AnimationIdleToRun();
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            _characterController.Move(direction * speed * Time.deltaTime);
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
