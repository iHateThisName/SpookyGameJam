using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadResizer : MonoBehaviour {
    private Camera mainCamera;
    private float quadHeight;
    private float quadWidth;

    void Start() {
        mainCamera = Camera.main;

        ResizeQuadToScreen();
    }

    void Update() {
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
    }


    void ResizeQuadToScreen() {
        float height = 2f * mainCamera.orthographicSize;
        float width = height * mainCamera.aspect;
        // Set the quad size to match the screen
        transform.localScale = new Vector3(width, height, 1f); // Quad is 1 unit deep, so depth is 1
    }
}
