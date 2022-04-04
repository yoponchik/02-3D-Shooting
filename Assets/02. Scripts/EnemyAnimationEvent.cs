using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEvent : MonoBehaviour
{

    public Enemy enemy;

    public void OnAttackHit() {
        enemy.OnAttackHit();
    }
}
