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
    [SerializeField] Lean.Touch.LeanSelect leanSelect;

    #endregion

    #region Methods
    public void ChangeCam(string cam)
    {
        if(cam == "normal")
        {
            leanSelect.Camera = normalCam;
        }else if(cam == "AR")
        {
            leanSelect.Camera = ARCam;
        }
    }
    #endregion
}
