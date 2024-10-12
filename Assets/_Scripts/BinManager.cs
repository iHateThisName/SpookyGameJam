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
            objectToSpawn.transform.position = this.transform.position;
            Destroy(this.gameObject);
        }
    }
}
