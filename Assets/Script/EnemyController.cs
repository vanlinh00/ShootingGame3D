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
    [SerializeField]
    Image _healthBar;

    private int randomPosition;
    float shootTime = 10f;
    private void Awake()
    {

    }
    private void Start()
    {
        _moveToPlayer = GameObject.Find(NetworkClient.ClientID).transform;
    }
    private void FixedUpdate()
    {
        if (transform != null)
        {
            float distanceEandPlayer = Vector3.Distance(transform.position, _moveToPlayer.position);
            float distanceEtoDestation = Vector3.Distance(transform.position, GameController.instance._listPoint[randomPosition].transform.position);

            if (distanceEandPlayer < 55f && (distanceEtoDestation > 2 * distanceEandPlayer || distanceEandPlayer < 40f))
            {
                MoveToPlayer(distanceEandPlayer);
            }
            else
            {
                // dung de cho 2 nemy shooting
                //int minDistanceBetween2Enemy = GameController.instance.checkMinMaxDistanceEnemy(this.transform)[0, 1];

                //if (minDistanceBetween2Enemy < 5)
                //{
                //    int pos = GameController.instance.checkMinMaxDistanceEnemy(this.transform)[0, 0];
                //    // enemyShooting(GameController.instance._listEnemy[pos].gameObject.transform.position);

                //}
                //else
                //{

                //}
                MoveToPoint((GameController.instance._listPoint[randomPosition].transform.position));
            }
        }
    }
    public void addRandomPosition(int a)
    {
        randomPosition = a;
    }
    void MoveToPoint(Vector3 target)
    {
        transform.LookAt(target);
        transform.Translate((target - transform.position) * speed);

        if ((Vector3.Distance(transform.position, target)) < 10f)
        {
            GameController.instance.RemoveGameObjectNull();
            randomPosition = GameController.instance.ranDomDestinationOfEnemy();
            // PlayerIdle();
        }
        else
        {
            PlayerRun();
        }
    }
    void MoveToPlayer(float distance)
    {
        transform.LookAt(_moveToPlayer.position);
        if (distance > 30f)
        {
            PlayerRun();
            //  transform.position = Vector3.Lerp(transform.position, _moveToPlayer.position, speed * Time.deltaTime);
            transform.Translate((_moveToPlayer.position - transform.position) * speed);
        }
        else
        {
            // PlayerIdle();
            shootTime -= Time.deltaTime;
            if (shootTime < 0)
            {
                enemyShooting(_moveToPlayer.position);
                shootTime = 3f;
            }

        }
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(20.0f);
    }

    public void muHealp(float n)
    {
        _healthBar.GetComponent<Image>().fillAmount -= n;
        base.health -= 1000;
        if (base.health == 0)
        {
            Destroy(this.gameObject);
            GameController.instance.RemoveGameObjectNull();

        }
    }
    public void enemyShooting(Vector3 positionPlayer)
    {
        Vector3 target = new Vector3();
        target.x = positionPlayer.x;
        target.y = positionPlayer.y + 2.0f;
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
