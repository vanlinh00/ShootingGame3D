using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyController : MoveController
{

    [SerializeField]
    float speed;

    [SerializeField]
    Transform _player;


    void Update()
    {
        float distance = Vector3.Distance(transform.position, _player.position);
        if (distance <= 10f)
        {
            AnimationRunToIdle();

        }
        else
        {
            AnimationIdleToRun();
            transform.position = Vector3.Lerp(transform.position, _player.position, speed * Time.deltaTime);
        }
        transform.LookAt(_player.position);

    }

}
