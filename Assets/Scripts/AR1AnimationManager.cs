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
    public GameObject rotateLeft;
    public GameObject rotateRight;
    public GameObject shutterButton;
    public BoxCollider indicatorCollider;
    
    #endregion

    #region Methods
    public void ToggleIndicator()
    {
        if (isObjectSpawn)
        {
            isObjectSpawn = false;
            indicator.SetActive(true);
            rotateLeft.SetActive(false);
            rotateRight.SetActive(false);
            shutterButton.SetActive(false);
            indicatorCollider.enabled = true;
        }
        else
        {
            isObjectSpawn = true;
            indicator.SetActive(false);
            rotateLeft.SetActive(true);
            rotateRight.SetActive(true);
            shutterButton.SetActive(true);
            indicatorCollider.enabled = false;
        }
    }
    public void ExitAR1()
    {
        indicator.SetActive(true);
        rotateLeft.SetActive(false);
        rotateRight.SetActive(false);
        shutterButton.SetActive(false);
        isObjectSpawn = false;
    }
    #endregion
}
