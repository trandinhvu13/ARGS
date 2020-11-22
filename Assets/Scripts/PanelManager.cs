using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    #region Singleton
    private static PanelManager _instance;

    public static PanelManager Instance { get { return _instance; } }

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
    public int currentPanelID = 1;
    [SerializeField] GameObject homePanel;
    [SerializeField] GameObject categoryPanel;
    [SerializeField] GameObject aboutUsPanel;
    [SerializeField] GameObject logInPanel;
    [SerializeField] GameObject searchBar;
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject productContent;
    #endregion
    #region Tweens
    [SerializeField] LeanTweenType panelTransitionTweenType;
    [SerializeField] float panelTransitionTweenTime;

    #endregion
    #region Methods
    public void MoveToPanel(int panelID)
    {
        if (panelID == currentPanelID)
        {
            return;
        }

        if (!LeanTween.isTweening(homePanel) && !LeanTween.isTweening(categoryPanel) && !LeanTween.isTweening(aboutUsPanel) && !LeanTween.isTweening(logInPanel))
        {
            GameEvent.Instance.ChangePanel(panelID);
            if (currentPanelID == 1)
            {
                LeanTween.scale(homePanel, Vector3.zero, 0).setEase(panelTransitionTweenType);
            }
            else if (currentPanelID == 2)
            {
                productContent.SetActive(false);
                LeanTween.scale(categoryPanel, Vector3.zero, 0).setEase(panelTransitionTweenType).setOnComplete(() =>
                {
                    GameEvent.Instance.ResetCategory();
                });
            }
            else if (currentPanelID == 3)
            {
                LeanTween.scale(aboutUsPanel, Vector3.zero, 0).setEase(panelTransitionTweenType);
            }
            else if (currentPanelID == 4)
            {
                LeanTween.scale(logInPanel, Vector3.zero, 0).setEase(panelTransitionTweenType);
                searchBar.SetActive(true);
            }

            if (panelID == 1)
            {
                searchBar.SetActive(true);
                LeanTween.scale(homePanel, new Vector3(1, 1, 1), panelTransitionTweenTime).setEase(panelTransitionTweenType).setOnComplete(ChangeCurrentPanel);
            }
            else if (panelID == 2)
            {
                searchBar.SetActive(true);
                LeanTween.scale(categoryPanel, new Vector3(1, 1, 1), panelTransitionTweenTime).setEase(panelTransitionTweenType).setOnComplete(() =>
                {
                    ChangeCurrentPanel();
                    productContent.SetActive(true);
                });
            }
            else if (panelID == 3)
            {
                searchBar.SetActive(true);
                LeanTween.scale(aboutUsPanel, new Vector3(1, 1, 1), panelTransitionTweenTime).setEase(panelTransitionTweenType).setOnComplete(ChangeCurrentPanel);
            }
            else if (panelID == 4)
            {
                LeanTween.scale(logInPanel, new Vector3(1, 1, 1), panelTransitionTweenTime).setEase(panelTransitionTweenType).setOnComplete(ChangeCurrentPanel);
                searchBar.SetActive(false);
            }
        }

        void ChangeCurrentPanel()
        {
            currentPanelID = panelID;

        }
    }
    #endregion
}
