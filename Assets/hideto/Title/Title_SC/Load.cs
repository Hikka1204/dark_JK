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
        if(Input.GetMouseButtonDown(0))
        {
            LoadingUi.SetActive(true);
            //StartCoroutine(LoadScene());
        }
    }
    //IEnumerator LoadScene()
    //{
    //    async = SceneManager.LoadSceneAsync("");  // シーンを移動

    //    while (!async.isDone)
    //    {
    //        Slider.value = async.progress;
    //        yield return null;
    //    }
    //}
}
