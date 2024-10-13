using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovment : MonoBehaviour {

    private float moveSpeed = 2f;
    private Transform player;

    public bool isAttacking = true;
    public bool isSuperFast = false;

    [SerializeField]
    private GameObject spriteDown;
    [SerializeField]
    private GameObject spriteUp;
    [SerializeField]
    private GameObject spriteLeft;
    [SerializeField]
    private GameObject spriteRight;

    private void Start() {
        moveSpeed = Random.Range(0.8f, 2f);
        if (isSuperFast) moveSpeed = 3.5f;
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

        #region Sprite
        // Prioritize movement based on the dominant axis (horizontal or vertical)
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) {
            // Horizontal movement is dominant
            if (direction.x < 0) {
                // Zombie moving left
                spriteDown.SetActive(false);
                spriteUp.SetActive(false);
                spriteLeft.SetActive(true);
                spriteRight.SetActive(false);
            } else if (direction.x > 0) {
                // Zombie moving right
                spriteDown.SetActive(false);
                spriteUp.SetActive(false);
                spriteLeft.SetActive(false);
                spriteRight.SetActive(true);
            }
        } else {
            // Vertical movement is dominant
            if (direction.y > 0) {
                // Zombie moving up
                spriteDown.SetActive(false);
                spriteUp.SetActive(true);
                spriteLeft.SetActive(false);
                spriteRight.SetActive(false);
            } else if (direction.y < 0) {
                // Zombie moving down
                spriteDown.SetActive(true);
                spriteUp.SetActive(false);
                spriteLeft.SetActive(false);
                spriteRight.SetActive(false);
            }
        }
        #endregion
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            isAttacking = true;
        }
    }
}
