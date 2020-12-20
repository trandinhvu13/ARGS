using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    #region Singleton
    private static AppManager _instance;

    public static AppManager Instance { get { return _instance; } }

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


    #region Stats
    [SerializeField] Camera normalCam;
    [SerializeField] Camera ARCam;
    public int selectedProduct = 0;
    public string currentScreen = "Normal";
    [SerializeField] Lean.Touch.LeanSelect leanSelect;
    [SerializeField] GameObject normalApp;
    [SerializeField] GameObject ar1App;
    #endregion

    #region Methods
    public void ChangeCam(string cam)
    {
        if (cam == "normal")
        {
            leanSelect.Camera = normalCam;
        }
        else if (cam == "AR")
        {
            leanSelect.Camera = ARCam;
        }
    }

    public void ChangeFunctionality(string screen)
    {
        if (screen == "AR1")
        {
            if (currentScreen == "Normal")
            {
                normalApp.SetActive(false);
                ar1App.SetActive(true);
            }
        }
        else if (screen == "Normal")
        {
            if (currentScreen == "AR1")
            {
                ar1App.SetActive(false);
                normalApp.SetActive(true);
                AR1AnimationManager.Instance.ExitAR1();
                ObjectSpawner.Instance.ExitAR1();
            }
        }
        currentScreen = screen;
    }
    #endregion
}
