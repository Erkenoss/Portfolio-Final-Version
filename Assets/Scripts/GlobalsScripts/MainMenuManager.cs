using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuManager : MonoBehaviour
{
    public List<GameObject> UIList = new List<GameObject>();
    public List<GameObject> mainListUI = new List<GameObject>();
    public List<GameObject> settingsListUI = new List<GameObject>();
    public List<Image> UIMark = new List<Image>();

    public float lastWidth;
    public float newWidthImage;

    private void Awake() {

        foreach (GameObject element in UIList) {
            element.SetActive(false);
        }

        foreach (Image img in UIMark) {
            img.enabled = false;
        }
    }

    public void NewGame() {
        SceneManager.LoadScene("StartScene");
    }

    public void GoURL(string url) {
        Application.OpenURL(url);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void ShowUI(GameObject UIElement) {
        UIElement.SetActive(true);
    }

    public void HideUI(GameObject UIElement) {
        UIElement.SetActive(false);
    }

    public void ShowOrHideUI(GameObject UIElement) {
        if (UIElement.activeSelf) {
            HideUI(UIElement);
        }
        else {
            UIActive(UIElement);
            ShowUI(UIElement);
        }
    }

    public void UIActive(GameObject UIElement) {
        foreach(GameObject UI in settingsListUI) {
            if (UI.name == UIElement.name) {
                continue;
            }
            else {
               UI.SetActive(false);
            }
        }
    }

    public void CloseList(GameObject UI) {
        List<GameObject> newList = UI.name == "MainMenu" ? mainListUI : settingsListUI;

        if (newList != null && newList.Count > 0) {
            foreach (GameObject element in newList) {
                element.SetActive(false);
            }
        }
    }


    #region Sprite

    public void ChangeWidth(Image img) {
        RectTransform rectTransform = img.rectTransform;
        rectTransform.sizeDelta = new Vector2(newWidthImage, rectTransform.sizeDelta.y);
    }

    public void LastWidth(Image img) {
        RectTransform rectTransform = img.rectTransform;
        rectTransform.sizeDelta = new Vector2(lastWidth, rectTransform.sizeDelta.y);
    }

    public void ShowUIMark(Image img) {
       img.enabled = true;
    }

    public void HideUIMark(Image img) {
       img.enabled = false;
    }
    #endregion

}
