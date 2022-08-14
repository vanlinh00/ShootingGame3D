using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class HelicopterController : MonoBehaviour
{
    /// chua co y tuong
    float shootTime = 3f;
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        shootTime -= Time.deltaTime;
        if (shootTime < 0)
        {
            EnemyMove();
            shootTime = 3f;
        }
    }
    private void EnemyMove()
    {
        float x = Random.RandomRange(-15, 15);
        float z = Random.RandomRange(-15, 15);
        Vector3 newPosition = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
        transform.DOMove(newPosition, 0.5f);
    }



}
