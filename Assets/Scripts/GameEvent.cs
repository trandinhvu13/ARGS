using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    #region Singleton
    private static GameEvent _instance;

    public static GameEvent Instance { get { return _instance; } }


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

    public event Action<int> OnChangePanel;
    public void ChangePanel(int panelID)
    {
        OnChangePanel?.Invoke(panelID);
    }

    public event Action OnResetCategory;
    public void ResetCategory()
    {
        OnResetCategory?.Invoke();
    }

}
