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


    [SerializeField]
    Transform _posGun;

    void Start()
    {

    }
    void Update()
    {

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

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

                GameObject _newBullet = Instantiate(Resources.Load("Bullet", typeof(GameObject)), _posGun.position, _posGun.rotation) as GameObject;
                _newBullet.GetComponent<Bullet>()._firePoint = GameController.instance._listEnemy[GameController.instance._listEnemy.Count - 1].transform;

                Destroy(_newBullet, 5);
            }
            if (Input.GetKeyUp("space"))
            {
                AnimationShootToIdle();

            }

        }
        // transform.LookAt(GameController.instance._listEnemy[GameController.instance._listEnemy.Count - 1].transform.position);

    }

}
