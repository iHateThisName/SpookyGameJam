using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {
    public CircleSliderManager circleSliderManager;
    private int sanity = 3;

    [SerializeField]
    private float speed = 4;
    [SerializeField]
    private bool canInteract = false;

    [SerializeField]
    private GameObject spriteDown;
    [SerializeField]
    private GameObject spriteUp;
    [SerializeField]
    private GameObject spriteLeft;
    [SerializeField]
    private GameObject spriteRight;

    void Start() {
        spriteDown.SetActive(true);
        spriteUp.SetActive(false);
        spriteLeft.SetActive(false);
        spriteRight.SetActive(false);
    }

    void Update() {
        float horizontalDirection = Input.GetAxis("Horizontal");
        float verticalDirection = Input.GetAxis("Vertical");
        Vector2 movementDirection = new Vector2(horizontalDirection, verticalDirection);

        transform.Translate(movementDirection * speed * Time.deltaTime);


        #region Sprite
        // W
        if (verticalDirection > 0) {
            spriteDown.SetActive(false);
            spriteUp.SetActive(true);
            spriteLeft.SetActive(false);
            spriteRight.SetActive(false);
        }
        // S
        else if (verticalDirection < 0) {
            spriteDown.SetActive(true);
            spriteUp.SetActive(false);
            spriteLeft.SetActive(false);
            spriteRight.SetActive(false);
        }
        // A
        else if (horizontalDirection < 0) {
            spriteDown.SetActive(false);
            spriteUp.SetActive(false);
            spriteLeft.SetActive(true);
            spriteRight.SetActive(false);
        }
        // D
        else if (horizontalDirection > 0) {
            spriteDown.SetActive(false);
            spriteUp.SetActive(false);
            spriteLeft.SetActive(false);
            spriteRight.SetActive(true);
        }
        #endregion

        if (canInteract) {
            if (Input.GetKey(KeyCode.E)) {
                circleSliderManager.fillValue++;
            } else if (circleSliderManager.fillValue > 0) {
                circleSliderManager.fillValue--;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Compactor")) {
            canInteract = true;
        }
    }

    public void PlayerDeath() {
        sanity--;
        if (sanity <= 0) {
            //GameManager.Instance.LoadScene(EnumScene.GameOverScene);
            GameManager.Instance.LoadScene(EnumScene.MainMenu);
        }
    }
}
