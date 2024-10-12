using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }
    public int days = 0;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void LoadScene(EnumScene scene) {
        SceneManager.LoadScene((int)scene);
        days++;
    }
}
