using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovment : MonoBehaviour {

    private float moveSpeed = 2f;
    private Transform player;

    public bool isAttacking = true;

    private void Start() {
        moveSpeed = Random.Range(0.8f, 2f);
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

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            isAttacking = true;
        }
    }
}
