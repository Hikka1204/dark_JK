using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour {

    private AsyncOperation async;
    public GameObject LoadingUi;
    public Slider Slider;

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !LoadingUi.activeSelf)
        {
            LoadingUi.SetActive(true);
            StartCoroutine(LoadScene());
        }
    }
    IEnumerator LoadScene()
    {
        async = SceneManager.LoadSceneAsync("Main");  // シーンを移動
        async.allowSceneActivation = false;

        float time = 0;

        while (!async.isDone)
        {
            Slider.value = async.progress;
            time += Time.deltaTime;
            yield return null;

            if(Slider.value >= 0.9f && time > 2.0f)
            {
                async.allowSceneActivation = true;
            }
        }
    }
}
