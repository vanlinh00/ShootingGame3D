using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyController : BasePlayerController
{

    [SerializeField]
    float speed;
    float hp;

    Transform _moveToPlayer;

    [SerializeField]
    CharacterController _characterController;

    int randomPosition;
    private void Awake()
    {
        hp = 3;
    }
    private void Start()
    {
        randomPosition = ranDomPosPlayer();
    }
    private void FixedUpdate()
    {
        FindAndMovePlayer();
    }
    void FindAndMovePlayer()
    {
        _moveToPlayer = GameController.instance._listPlayer[randomPosition].transform;

        float distance = Vector3.Distance(transform.position, _moveToPlayer.position);
        if (distance <= 50f && distance >= 20f)
        {
            AnimationIdleToRun();
            transform.position = Vector3.Lerp(transform.position, _moveToPlayer.position, speed * Time.deltaTime);
        }
        else
        {
            // AnimationRunToIdle();
            AnimationIdleToRun();

        }

        transform.LookAt(_moveToPlayer.position);
    }
    void EnemyMove()
    {
        float randomZ = Random.Range(-10, 10);
        float randomX = Random.Range(-10, 10);

        Vector3 direction = new Vector3(transform.position.x + randomX, 0, transform.position.z + randomZ).normalized;
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
        }

    }
    int ranDomPosPlayer()
    {
        randomPosition = 0;

        while (Vector3.Distance(transform.position, GameController.instance._listPlayer[randomPosition].transform.position) == 0) ;
        {
            randomPosition = Random.RandomRange(0, 1);

        }
        return randomPosition;
    }
    IEnumerator ExampleCoroutine()
    {

        yield return new WaitForSeconds(900000);
    }

}
