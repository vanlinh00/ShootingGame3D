using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorPlayerController : MonoBehaviour
{
    [SerializeField]
    float speed;

    float horizontalInput;
    float verticalInput;
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        //horizontalInput = Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");
        //if (Mathf.Abs(verticalInput) > 0)
        //{
        //    _animator.SetBool("run", false);
        //}
        //else
        //{
        //    _animator.SetBool("run", true);
        //}

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        Debug.Log(horizontalInput);
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        if (direction.magnitude >= 0.1f)
        {
            _animator.SetBool("run", false);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.Translate(direction * speed);
        }
        else
        {
            _animator.SetBool("run", true);
        }


    }

}
