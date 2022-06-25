using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;
using DG.Tweening;
// khi co dan bat vao no thi no phai chay ra cho khau

// neu co the cho boss ban nhau
// neu co the cho 2 enemy ban nhau


public class EnemyController : BasePlayerController
{
    [SerializeField]
    float speed;
    [SerializeField]
    Transform _moveToPlayer;

    [SerializeField]
    CharacterController _characterController;

    private int randomPosition;
    float shootTime = 3f;
    private void Awake()
    {

    }
    private void Start()
    {
        _moveToPlayer = GameObject.Find(NetworkClient.ClientID).transform;
    }
    private void FixedUpdate()
    {
        float distanceEtoPlayer = Vector3.Distance(transform.position, _moveToPlayer.position);
        float distanceEtoDestation = Vector3.Distance(transform.position, GameController.instance._listPoint[randomPosition].transform.position);

        if (distanceEtoPlayer < 55f && (distanceEtoDestation > 2 * distanceEtoPlayer) || distanceEtoPlayer < 40f)
        {
            MoveToPlayer(distanceEtoPlayer);
        }
        else
        {
            /*
            int minDistanceBetween2Enemy = GameController.instance.CheckMinMaxDistanceEnemy(this.transform)[0, 1];
            //  Debug.Log("palyer" + GameController.instance.CheckMinMaxDistanceEnemy(this.transform)[0, 1]);
            if (minDistanceBetween2Enemy < 39f)
            {
                int pos = GameController.instance.CheckMinMaxDistanceEnemy(this.transform)[0, 0];
                shootTime -= Time.deltaTime;
                if (shootTime < 0)
                {
                    Debug.Log("dang bat enemy");
                    EnemyShooting(GameController.instance._listEnemy[pos].gameObject.transform.position);
                    shootTime = 7f;
                }
            }
            else
            {
                MoveToPoint((GameController.instance._listPoint[randomPosition].transform.position));
            }
            */
            MoveToPoint((GameController.instance._listPoint[randomPosition].transform.position));
        }
    }
    public void addRandomPosition(int a)
    {
        randomPosition = a;
    }
    void MoveToPoint(Vector3 target)
    {
        if ((Vector3.Distance(transform.position, target)) <= 20f)
        {
            randomPosition = GameController.instance.ranDomDestinationOfEnemy();
        }
        else
        {
            transform.LookAt(target);
            PlayerRun();
            transform.Translate((target - transform.position) * speed);
        }
    }
    void MoveToPlayer(float distance)
    {
        transform.LookAt(_moveToPlayer.position);
        if (distance > 33f)
        {
            PlayerRun();
            //  transform.position = Vector3.Lerp(transform.position, _moveToPlayer.position, speed * Time.deltaTime);
            transform.Translate((_moveToPlayer.position - transform.position) * speed);
        }
        else
        {
            shootTime -= Time.deltaTime;
            if (shootTime < 0)
            {
                Playershoot();
                EnemyShooting(_moveToPlayer.position);
                shootTime = 3f;
            }
            // else
            //{
            //    PlayerIdle();
            //}
        }
    }
    public void EnemyShooting(Vector3 positionPlayer)
    {
        transform.LookAt(positionPlayer);
        Vector3 target = new Vector3();
        target.x = positionPlayer.x;
        target.y = positionPlayer.y + 2f;
        target.z = positionPlayer.z;
        Shooting(target);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            EnemyMove();
        }
    }
    private void EnemyMove()
    {
        float x = Random.RandomRange(-3, 3);
        float z = Random.RandomRange(-3, 3);
        Vector3 newPosition = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
        PlayerRun();
        transform.DOMove(newPosition, 0.5f);
    }
}
