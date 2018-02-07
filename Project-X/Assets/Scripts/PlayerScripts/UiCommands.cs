using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiCommands : MonoBehaviour {

    bool toggle = true;

    [SerializeField]
    GameObject options;
    Slider sliderAudio;

    public void LoadSceneByIndex (int x) {
        SceneManager.LoadScene(x);
        Debug.Log("Loaded scene:" + x);
    }

    public void Exit() {
        Application.Quit();
    }

    public void ToggleScreen (){
        options.SetActive(toggle);
        toggle = !toggle;
    }

    public void VolumeUpdate() {
        PlayerPrefs.SetFloat("volume", sliderAudio.value);
    }
}
