using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyController : BasePlayerController
{

    [SerializeField]
    float speed;
    float hp;
    [SerializeField]
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
        // randomPosition = ranDomPosPlayer();

        randomPosition = Random.RandomRange(0, GameController.instance._listPoint.Count - 1);
        Debug.Log(randomPosition);
    }
    private void FixedUpdate()
    {
        // FindAndMovePlayer();
        MoveToPoint();
    }

    void MoveToPoint()
    {
        transform.LookAt((GameController.instance._listPoint[randomPosition].transform.position));
        transform.Translate((GameController.instance._listPoint[randomPosition].transform.position - transform.position) * speed);

        if ((Vector3.Distance(transform.position, GameController.instance._listPoint[randomPosition].transform.position)) < 1f)
        {
            AnimationRunToIdle();
        }
        else
        {
            AnimationIdleToRun();
        }
    }



    // ideal da delete
    void FindAndMovePlayer()
    {
        //   _moveToPlayer = GameController.instance._listPlayer[randomPosition].transform;

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
