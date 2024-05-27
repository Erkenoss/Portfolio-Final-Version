using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public List<GameObject> UIList = new List<GameObject>();
    public List<GameObject> mainListUI = new List<GameObject>();
    public List<GameObject> settingsListUI = new List<GameObject>();

    private void Awake() {

        foreach (GameObject element in UIList) {
            element.SetActive(false);
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
            ShowUI(UIElement);
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
}
