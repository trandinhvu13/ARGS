using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Category : MonoBehaviour
{
    #region Variable
    private int currentTab = 1;
    [SerializeField] Image potteryImage;
    [SerializeField] Image decorImage;

    [SerializeField] Sprite normalPottery;
    [SerializeField] Sprite selectedPottery;
    [SerializeField] Sprite normalDecor;
    [SerializeField] Sprite selectedDecor;

    [SerializeField] GameObject potteryGameObject;
    [SerializeField] GameObject decorGameObject;

    [SerializeField] GameObject contentPanel;
    [SerializeField] GameObject productPanel;

    [SerializeField] Image productImage;

    [SerializeField] Sprite product1; //con ngua
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject searchBar;
    [SerializeField] GameObject navBar;
    #endregion

    #region Tweens
    [SerializeField] LeanTweenType tabTransitionTweenType;
    [SerializeField] float tabTransitionTweenTime;

    [SerializeField] LeanTweenType productTweenType;
    [SerializeField] float productTweenTime;

    #endregion

    #region Mono
    private void OnEnable()
    {
        GameEvent.Instance.OnResetCategory += ResetCategory;
    }
    private void OnDisable()
    {
        GameEvent.Instance.OnResetCategory -= ResetCategory;
    }
    #endregion

    #region Methods
    public void ChangeTab(int tabID)
    {
        if (tabID == currentTab)
        {
            return;
        }
        if (!LeanTween.isTweening(decorGameObject) && !LeanTween.isTweening(potteryGameObject))
        {
            ChangeTabIcon(tabID);
            if (currentTab == 1)
            {
                LeanTween.scale(potteryGameObject, Vector3.zero, 0).setEase(tabTransitionTweenType);
            }
            else if (currentTab == 5)
            {
                LeanTween.scale(decorGameObject, Vector3.zero, 0).setEase(tabTransitionTweenType);
            }

            if (tabID == 1)
            {
                LeanTween.scale(potteryGameObject, new Vector3(1, 1, 1), 0).setOnComplete(ChangeCurrentPanel);
            }
            else if (tabID == 5)
            {
                LeanTween.scale(decorGameObject, new Vector3(1, 1, 1), 0).setOnComplete(ChangeCurrentPanel);
            }
        }

        void ChangeCurrentPanel()
        {
            currentTab = tabID;
        }
    }
    public void ChangeTabIcon(int tabID)
    {
        potteryImage.sprite = normalPottery;
        decorImage.sprite = normalDecor;

        if (tabID == 1)
        {
            potteryImage.sprite = selectedPottery;
        }
        else if (tabID == 5)
        {
            decorImage.sprite = selectedDecor;
        }
    }
    public void ChooseProduct(int productID)
    {
        if (productID == 1)
        {
            productImage.sprite = product1;
        }

        navBar.SetActive(false);
        LeanTween.moveLocalX(contentPanel, -0.2f, productTweenTime).setEase(productTweenType);
        LeanTween.moveLocalX(productPanel, 0, productTweenTime).setEase(productTweenType);
        searchBar.SetActive(false);
        backButton.SetActive(true);

    }
    public void BackButton()
    {
        LeanTween.moveLocalX(contentPanel, 0f, productTweenTime).setEase(productTweenType);
        LeanTween.moveLocalX(productPanel, 0.2f, productTweenTime).setEase(productTweenType);
        navBar.SetActive(true);
        backButton.SetActive(false);
        searchBar.SetActive(true);
    }
    public void ResetCategory()
    {
        currentTab = 1;
        backButton.SetActive(false);
        contentPanel.transform.localPosition = new Vector3(0, 0, 0);
        productPanel.transform.localPosition = new Vector3(0.2f, 0, 0);
        potteryImage.sprite = selectedPottery;
        decorImage.sprite = normalDecor;
        LeanTween.scale(potteryGameObject, new Vector3(1, 1, 1), 0);
        LeanTween.scale(decorGameObject, Vector3.zero, 0);
    }
    #endregion

}
