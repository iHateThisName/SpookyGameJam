using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinManager : MonoBehaviour
{
    public CircleSliderManager circleSliderManager;


    public GameObject objectToSpawn;

    void Update()
    {
        if (circleSliderManager.fillValue > 99)
        {
            Debug.Log("filled bar");
            Instantiate(objectToSpawn);
            objectToSpawn.transform.position = new Vector3 (this.transform.position.x + -2, this.transform.position.y, this.transform.position.z);
            Destroy(this.gameObject);
        }
    }
}
