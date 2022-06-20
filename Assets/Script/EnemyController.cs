using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;
// khi co dan bat vao no thi no phai chay ra cho khac
// cho boss ban minh khi lai gan
// neu co the cho boss ban nhau
// moi con boss radom 1 vi tri 
// neu co the cho 2 enemy ban nhau
// lam cho 2 con khong di lien vao nhau
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
    float moveTime = 4f;
    float moveTimePlayer = 5f;
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
            float distance = Vector3.Distance(transform.position, _moveToPlayer.position);

            if (distance < 45f)
            {
                int minDistanceBetween2Enemy = GameController.instance.checkMinMaxDistanceEnemy(this.transform)[0, 1];

                if (minDistanceBetween2Enemy < 6)
                {
                    moveTime -= Time.deltaTime;
                    if (moveTime < 0)
                    {
                        int pos = GameController.instance.checkMinMaxDistanceEnemy(this.transform)[1, 0];
                        MoveToPoint(GameController.instance._listEnemy[pos].gameObject.transform.position);
                        moveTime = 4f;
                    }
                    else
                    {
                        PlayerIdle();
                    }
                }
                else
                {
                    moveTimePlayer -= Time.deltaTime;
                    if (moveTime < 0)
                    {
                        MoveToPlayer(distance);
                        moveTimePlayer = 4f;
                    }
                    else
                    {
                        PlayerIdle(); ;
                    }
                }
            }
            else
            {
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
            PlayerIdle();
            GameController.instance.RemoveGameObjectNull();
            randomPosition = GameController.instance.ranDomDestinationOfEnemy();
        }
        else
        {
            PlayerRun();
        }
    }
    void MoveToPlayer(float distance)
    {
        transform.LookAt(_moveToPlayer.position);
        if (distance > 20f)
        {
            PlayerRun();
            //  transform.position = Vector3.Lerp(transform.position, _moveToPlayer.position, speed * Time.deltaTime);
            transform.Translate((_moveToPlayer.position - transform.position) * speed);
        }
        else
        {
            PlayerIdle();
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
        if (collision.gameObject.tag.Equals("Player"))
        {

        }
    }
}
