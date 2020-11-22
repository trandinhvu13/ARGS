using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NavBar : MonoBehaviour
{
    #region Sprites
    [SerializeField] Sprite normalHome;
    [SerializeField] Sprite selectedHome;
    [SerializeField] Sprite normalCategory;
    [SerializeField] Sprite selectedCategory;
    [SerializeField] Sprite normalAboutUs;
    [SerializeField] Sprite selectedAboutUs;
    [SerializeField] Sprite normalLogin;
    [SerializeField] Sprite selectedLogin;

    [SerializeField] Image homeImage;
    [SerializeField] Image categoryImage;
    [SerializeField] Image loginImage;
    [SerializeField] Image aboutUsImage;
    #endregion

    private void OnEnable()
    {
        GameEvent.Instance.OnChangePanel += ChangePanel;
    }
    private void OnDisable()
    {
        GameEvent.Instance.OnChangePanel -= ChangePanel;
    }

    #region Methods
    private void ChangePanel(int panelID)
    {
        homeImage.sprite = normalHome;
        categoryImage.sprite = normalCategory;
        aboutUsImage.sprite = normalAboutUs;
        loginImage.sprite = normalLogin;

        if (panelID == 1)
        {
            homeImage.sprite = selectedHome;
        }
        else if (panelID == 2)
        {
            categoryImage.sprite = selectedCategory;
        }
        else if (panelID == 3)
        {
            aboutUsImage.sprite = selectedAboutUs;
        }
        else if (panelID == 4)
        {
            loginImage.sprite = selectedLogin;
        }
    }
    #endregion

}
