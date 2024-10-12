using UnityEngine;

public class ExitController : MonoBehaviour {
    [SerializeField] private EnumScene scene = EnumScene.MainMenu;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Debug.Log("Exit");
            GameManager.Instance.LoadScene(scene);
        }
    }
}
