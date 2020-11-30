using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR1AnimationManager : MonoBehaviour
{
    #region Singleton
    private static AR1AnimationManager _instance;

    public static AR1AnimationManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    #region Variables
    [SerializeField] GameObject indicator;
    public bool isObjectSpawn = false;
    #endregion

    #region Methods
    public void ToggleIndicator()
    {
        if (isObjectSpawn)
        {
            isObjectSpawn = false;
            indicator.SetActive(false);
        }
        else
        {
            isObjectSpawn = true;
            indicator.SetActive(true);
        }
    }
    #endregion
}
