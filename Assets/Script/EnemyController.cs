using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.UI;
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

    int randomPosition = 0;
    bool isPlayer = false;
    float shootTime = 10f;
    private void Awake()
    {

    }
    private void Start()
    {
        randomPosition = Random.RandomRange(0, GameController.instance._listPoint.Count);
        _moveToPlayer = GameObject.Find(NetworkClient.ClientID).transform;
    }
    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, _moveToPlayer.position);
        if (distance < 40f)
        {
            MoveToPlayer(distance);
        }
        else
        {
            MoveToPoint();
        }

    }
    void MoveToPoint()
    {
        transform.LookAt((GameController.instance._listPoint[randomPosition].transform.position));
        transform.Translate((GameController.instance._listPoint[randomPosition].transform.position - transform.position) * speed);

        if ((Vector3.Distance(transform.position, GameController.instance._listPoint[randomPosition].transform.position)) < 10f)
        {
            AnimationRunToIdle();
            randomPosition = Random.RandomRange(0, GameController.instance._listPoint.Count);
        }
        else
        {
            AnimationIdleToRun();
        }
    }
    void MoveToPlayer(float distance)
    {
        transform.LookAt(_moveToPlayer.position);
        if (distance > 20f)
        {
            AnimationIdleToRun();
            //  transform.position = Vector3.Lerp(transform.position, _moveToPlayer.position, speed * Time.deltaTime);
            transform.Translate((_moveToPlayer.position - transform.position) * speed);
        }
        else
        {
            AnimationRunToIdle();
            shootTime -= Time.deltaTime;
            if (shootTime < 0)
            {
                enemyShooting(_moveToPlayer.position);
                shootTime = 10f;
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
}
