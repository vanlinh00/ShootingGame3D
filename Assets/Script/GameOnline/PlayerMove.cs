using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private NetworkIdentity networkIndentity;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (networkIndentity.IsControlling())
        {
            Move();
        }

    }
    public void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontal, 0, vertical);
        transform.Translate(move * Time.deltaTime * 2f);
    }
}
