using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public static class EventManager
{
    public static event UnityAction EnemyDeath;
    public static void OnEnemyDeath() => EnemyDeath?.Invoke();  // phat ra su kien la co thang goi on enemyDeath
}
