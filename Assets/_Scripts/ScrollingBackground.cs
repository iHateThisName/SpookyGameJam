using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {
    public Transform player;
    public float parallaxEffectMultiplier = 0.5f;  // Parallax effect multiplier
    private Vector2 lastPlayerPosition;  // To track the player's previous position
    private Renderer quadRenderer;

    void Start() {
        quadRenderer = GetComponent<Renderer>();
        lastPlayerPosition = player.position;
    }

    void Update() {
        // Calculate the movement based on player's movement
        Vector2 playerDelta = (Vector2)player.position - lastPlayerPosition;
        quadRenderer.material.mainTextureOffset += playerDelta * parallaxEffectMultiplier;
        // Update the last player position for the next frame
        lastPlayerPosition = player.position;
    }
}
