using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    public void Deactivate()
    {
        if (AR1AnimationManager.Instance.isObjectSpawn)
        {
            AR1AnimationManager.Instance.ToggleIndicator();
            Destroy(gameObject);
        }
    }
}
