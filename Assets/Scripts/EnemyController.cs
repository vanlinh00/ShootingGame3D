using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;
using DG.Tweening;

public class EnemyController : BasePlayerController, IDamageable
{
    [SerializeField] float speed;

    [SerializeField] Transform _moveToPlayer;


    [SerializeField] CharacterController _characterController;

    private int randomPosition;
    float shootTime = 3f;
    float shootTimeOld;
    private void Awake()
    {
        shootTimeOld = 3f;
    }
    private void Start()
    {
        _moveToPlayer = GameObject.Find("Player").transform;
    }
    private void FixedUpdate()
    {
        float distanceEtoPlayer = Vector3.Distance(transform.position, _moveToPlayer.position);
        float distanceEtoDestation = Vector3.Distance(transform.position, EnemyManager.instance._listPoint[randomPosition].transform.position);

        if (distanceEtoPlayer < 55f && (distanceEtoDestation > 2 * distanceEtoPlayer) || distanceEtoPlayer < 40f)
        {
            MoveToPlayer(distanceEtoPlayer);
        }
        else
        {
            // 2 enemy shooting
            int minDistanceBetween2Enemy = EnemyManager.instance.CheckMinMaxDistanceEnemy(this.transform)[0, 1];
            if (minDistanceBetween2Enemy < 19f && minDistanceBetween2Enemy != 0)
            {
                int pos = EnemyManager.instance.CheckMinMaxDistanceEnemy(this.transform)[0, 0];

                shootTime -= Time.deltaTime;
                if (shootTime < 0)
                {
                    Playershoot();
                    Shooting(EnemyManager.instance._listEnemy[pos].gameObject.transform.position);
                    shootTime = shootTimeOld;
                }
            }
            else
            {
                PlayerRun();
                MoveToPoint((EnemyManager.instance._listPoint[randomPosition].transform.position));
            }
            // MoveToPoint((GameController.instance._listPoint[randomPosition].transform.position));
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
            randomPosition = EnemyManager.instance.ranDomDestinationOfEnemy();
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
                Shooting(_moveToPlayer.position);
                shootTime = shootTimeOld;
            }
        }
    }
    protected override void Shooting(Vector3 positionPlayer)
    {
        float yRandom = Random.RandomRange(-4, 4);

        transform.LookAt(positionPlayer);
        Vector3 target = new Vector3();
        target.x = positionPlayer.x;
        target.y = positionPlayer.y + yRandom;
        target.z = positionPlayer.z;
        base.Shooting(target);
    }
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            base.OnCollisionEnter(collision);
            EnemyMove();
        }
    }
    private void EnemyMove()
    {
        float x = Random.RandomRange(-2, 2);
        float z = Random.RandomRange(-2, 2);
        Vector3 newPosition = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
        PlayerRun();
        transform.DOMove(newPosition, 0.5f);
    }

    public void Damage()
    {
        _healthBar.GetComponent<Image>().fillAmount -= 0.1f;
        health -= 1000;
        if (health <= 0)
        {
            List<GameObject> listObjectBlood = new List<GameObject>();

            int arrayCount = _positionOfParticleBlood.childCount;

            for (int i = 0; i < arrayCount; i++)
            {
                listObjectBlood.Add(_positionOfParticleBlood.GetChild(i).gameObject);
            }
            foreach (GameObject index in listObjectBlood)
            {
                index.transform.parent = ObjectPooler.Instance.transform;
            }

            if (_positionOfParticleBlood.childCount == 0)
            {
                EventManager.OnEnemyDeath();
                Destroy(this.gameObject);
            }
        }

    }
}
