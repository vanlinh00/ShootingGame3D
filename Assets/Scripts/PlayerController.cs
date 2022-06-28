//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerController : BasePlayerController
//{

//    [SerializeField]
//    CharacterController _characterController;

//    [SerializeField]
//    float speed;
//    float horizontalInput;
//    float verticalInput;

//    float turnSoothTime = 0.1f;
//    float turnSoomthVelocity;


//    Vector3 _shootPoint;

//    void Start()
//    {

//    }
//    private void Update()
//    {
//        MovePlayer();
//    }
//    void MovePlayer()
//    {

//        horizontalInput = Input.GetAxis("Horizontal");
//        verticalInput = Input.GetAxis("Vertical");
//        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

//        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
//        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);

//        if (Physics.Raycast(ray, out RaycastHit raycastHit))
//        {
//            _shootPoint = raycastHit.point;
//            transform.LookAt(_shootPoint);
//        }

//        if (Input.GetKeyDown("q"))
//        {
//            CameraController.instance.PlayerSniperCult(true);
//            UiController.instance.UiGun(false);
//            UiController.instance.UiSniperCult(true);
//        }
//        else if (Input.GetKeyUp("q"))
//        {
//            CameraController.instance.PlayerSniperCult(false);
//            UiController.instance.UiGun(true);
//            UiController.instance.UiSniperCult(false);
//            PlayerIdle();
//        }
//        if (Input.GetMouseButtonDown(0))
//        {
//            Shooting(_shootPoint);
//        }

//        if (direction.magnitude >= 0.1f)
//        {
//            PlayerRun();

//            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
//            float angle = Mathf.SmoothDampAngle(transform.localEulerAngles.y, targetAngle, ref turnSoomthVelocity, turnSoothTime);

//            transform.rotation = Quaternion.Euler(0f, angle, 0f);

//            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
//            _characterController.Move(moveDir.normalized * speed * Time.deltaTime);
//        }
//        else
//        {
//            PlayerIdle();

//        }

//    }



//}
