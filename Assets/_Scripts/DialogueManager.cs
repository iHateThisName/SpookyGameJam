using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

    public GameObject[] dialogText;
    private int currentDialogueIndex = 0;

    private void Start() {
        //sort dialog text based on name
        //System.Array.Sort(dialogText, (a, b) => string.Compare(a.name, b.name));

        //foreach (GameObject dialog in dialogText) {
        //    Debug.Log(dialog.name);

        //}
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            NextDialogue();
        }
    }

    private void SetDialogueTextActive(int index) {
        if (index <= dialogText.Length - 1) {
            dialogText[index].SetActive(true);
        } else {
            Debug.Log("Load next Scene dialog finished");
        }
    }

    private void NextDialogue() {
        dialogText[currentDialogueIndex].SetActive(false);
        currentDialogueIndex++;
        SetDialogueTextActive(currentDialogueIndex);
    }
}
