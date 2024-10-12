using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private float speed = 4;
    [SerializeField]
    private bool canInteract = false;
    public CircleSliderManager circleSliderManager;

    public GameObject objectToSpawn;
    public GameObject objectToSpawnPrefab;

    void Update()
    {
        float HorizontalDirection = Input.GetAxis("Horizontal");
        float VerticalDirection = Input.GetAxis("Vertical");
        Vector2 movementDirection = new Vector2(HorizontalDirection, VerticalDirection);

        transform.Translate(movementDirection * speed * Time.deltaTime);


        if (canInteract)
        {
            if (Input.GetKey(KeyCode.E))
            {
                circleSliderManager.fillValue++;
            }
            else if (circleSliderManager.fillValue > 0)
            {
                circleSliderManager.fillValue--;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Compactor"))
        {
            canInteract = true;
        }
    }
}

/*
 * [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

       if (Mathf.Abs(horizontalInput) > Mathf.Abs(verticalInput))
        {
            verticalInput = 0;
        }
        else
        {
            horizontalInput = 0;
        }

       Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * inputMagnitude * Time.deltaTime, Space.World);

        if (movementDirection != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }*/