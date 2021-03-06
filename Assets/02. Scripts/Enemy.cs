using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //Navmesh
    NavMeshAgent agent;
    GameObject target;

    //Animation
    public Animator anim;

    //State Machine
    public State state;

    //HP
    public EnemyHP enemyHP;

    public enum State { 
        Idle, 
        Walk, 
        Attack
    }

    void Start()
    {
        //Navmesh Agent
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");

        //State Machine
        state = State.Idle;
    }

    void Update()
    {
        if (state == State.Idle) {
            UpdateIdle();
        }
        else if (state == State.Walk) {
            UpdateWalk();
        }
        else if (state == State.Attack) {
            UpdateAttack();
        }
    }


    private void UpdateIdle() {
        //look for Player
        target = GameObject.FindGameObjectWithTag("Player");

/*        if (target != null) {
            state = State.Walk;
            anim.SetTrigger("Walk");
        }*/

        if (target == null) { return; }

        //if Player found -> go to Walk
        state = State.Walk;
        anim.SetTrigger("Walk");                                    //Shouldn't put this in the UpdateWalk b/c we aren't constantly updating it
                                                                    //We are only triggering the animation once. 
    }


    private void UpdateWalk() {
        
        agent.SetDestination(target.transform.position);            //Tell Agent the destination
        //if the distance between the agent and the player is less than or equal to the stopping distance
        float distance = Vector3.Distance(transform.position, target.transform.position);
        //change to attack state
        if (distance <= agent.stoppingDistance) { 
            state = State.Attack;
            anim.SetTrigger("Attack");
        }
    }

    private void UpdateAttack() {

    }

    internal void OnAttackHit() {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= agent.stoppingDistance) {
            EnemyHitManager.instance.Hit();
        }
    }
    internal void ShotByGun() {
        //decrease enemy HP
        enemyHP.HP--;
        //if Hp == 0, Destroy
        if (enemyHP.HP <= 0) { 
            Destroy(gameObject, 0.2f);
        }
    }
    internal void HitByBomb() {
        enemyHP.HP-= 2;
        //if Hp == 0, Destroy
        if (enemyHP.HP <= 0) {
            Destroy(gameObject, 0.1f);
        }
    }

}
