using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {
    [SerializeField]
    private float speed = 4;

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
        //transform.Translate(horizontalDirection * speed * Time.deltaTime * Vector2.right);

        Vector2 movementDirection = new Vector2(horizontalDirection, verticalDirection);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * inputMagnitude * Time.deltaTime);

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
    }
}
