using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject conNgua;
    [SerializeField]
    private PlacementIndicator placementIndicator;
    [SerializeField]
    private GameObject spawnedObject;
    public float rotateSpeed = 10;



    void Start()
    {


    }

    public void Activate()
    {
        if (!AR1AnimationManager.Instance.isObjectSpawn)
        {
            objectToSpawn = SelectProduct();
            AR1AnimationManager.Instance.ToggleIndicator();
            spawnedObject = Instantiate(objectToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);
            objectToSpawn = null;
        }
    }
    

    public GameObject SelectProduct()
    {
        if (AppManager.Instance.selectedProduct == 1)
        {
            return conNgua;
        }
        else
        {
            return null;
        }
    }

    public void RotateProduct(string dir)
    {
        if (spawnedObject == null)
        {
            return;
        }

        if (dir == "left")
        {
            spawnedObject.transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
        }
        else if (dir == "right")
        {
            spawnedObject.transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }
    }
}
