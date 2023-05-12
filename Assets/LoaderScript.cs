using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoaderScript : MonoBehaviour
{

    public GameObject sceneLoad;
    public Slider slider;

    public void Loader(int sceneIndex)
    {
        StartCoroutine(LoadingScene(sceneIndex));
    }

    IEnumerator LoadingScene(int sceneIndex)
    {
        AsyncOperation proses =  SceneManager.LoadSceneAsync(sceneIndex);
        sceneLoad.SetActive(true);

        while(!proses.isDone)
        {
            float progress = Mathf.Clamp01(proses.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}
