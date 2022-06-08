using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MoveController
{
    [SerializeField]
    CharacterController _characterController;

    [SerializeField]
    float speed;
    float horizontalInput;
    float verticalInput;
    bool isSpace;
    void Start()
    {

    }
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown("space"))
        {
            isSpace = true;

        }
        if (Input.GetKeyUp("space"))
        {
            isSpace = false;

        }
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
            if (isSpace)
            {
                AnimationIdleToShoot();
            }
            else
            {
                AnimationShootToIdle();
            }

        }

    }

}
