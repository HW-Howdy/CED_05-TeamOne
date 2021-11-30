using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickButton : MonoBehaviour {
    public void ClickStartButton() {
        SceneManager.LoadScene("GameScene");
    }

    public void ClickEndButton() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void ClickTitleButton() {
        SceneManager.LoadScene("TitleScene");
    }
}
