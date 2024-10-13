using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public int medicineType;
    public Sprite[] medicineSprites;
    public float medicineChillPill;

    void Start()
    {
        medicineType = Random.Range(0, 2);

        switch (medicineType)
        {
            case 0:
                medicineChillPill = 20;
                this.GetComponent<SpriteRenderer>().sprite = medicineSprites[0];
                break;
            case 1:
                medicineChillPill = -30;
                this.GetComponent<SpriteRenderer>().sprite = medicineSprites[1];
                break;
            default:
                medicineChillPill = 0;
                this.GetComponent<SpriteRenderer>().sprite = medicineSprites[0];
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("GameUI").GetComponent<UserInterfaceManager>().timeLeft = 
                GameObject.Find("GameUI").GetComponent<UserInterfaceManager>().timeLeft + medicineChillPill;
            PickedUp();
        }
    }

    void PickedUp()
    {
        Destroy(gameObject);
    }
}