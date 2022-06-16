using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.UI;
// khi co dan bat vao no thi no phai chay ra cho khac
// cho boss ban minh khi lai gan
// neu co the cho boss ban nhau
// moi con boss radom 1 vi tri 
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

    private void Awake()
    {

    }
    private void Start()
    {
        randomPosition = Random.RandomRange(0, GameController.instance._listPoint.Count);
    }
    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, _moveToPlayer.position);
        if (distance < 30f)
        {
            MoveToPlayer();
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
    void MoveToPlayer()
    {
        transform.LookAt(_moveToPlayer.position);
        AnimationIdleToRun();
        transform.position = Vector3.Lerp(transform.position, _moveToPlayer.position, speed * Time.deltaTime);

    }
    IEnumerator ExampleCoroutine()
    {

        yield return new WaitForSeconds(5);
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
}
