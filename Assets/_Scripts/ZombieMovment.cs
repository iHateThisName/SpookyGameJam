using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovment : MonoBehaviour {

    public float moveSpeed = 2f;
    private Transform player;

    public bool isAttacking = true;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update() {
        if (player != null) {
            if (isAttacking) AttackPlayer();
        }
    }

    private void AttackPlayer() {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }
}
