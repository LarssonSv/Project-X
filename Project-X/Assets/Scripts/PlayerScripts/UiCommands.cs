using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.Playables;


public class UiCommands : MonoBehaviour {

    [SerializeField]
    private PlayableDirector toOptions, toMenu;

    private bool isFullscreen;
    
    [SerializeField]
    private AudioMixer audioMixer;

    public void LoadSceneByIndex (int x)
    {
        SceneManager.LoadScene(x);
        Debug.Log("Loaded scene:" + x);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void VolumeUpdate (float value) {
        audioMixer.SetFloat("Volume", value);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen (int num)
    {
        if (num == 0)
        {
            isFullscreen = true;
        }
        else
        {
            isFullscreen = false;
        }
        Screen.fullScreen = isFullscreen;
    }

    public void GoToOptions()
    {
        toOptions.Stop();
        toOptions.Play();
    }

    public void GoToMenu()
    {
        toMenu.Stop();
        toMenu.Play();
    }
}
