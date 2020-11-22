using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    private AsyncOperation operation;
    [SerializeField] GameObject quad;
    [SerializeField] LeanTweenType quadTweenType;
    [SerializeField] float quadTweenTime;

    private void Awake()
    {
        Application.targetFrameRate = 60;

    }
    private void Start()
    {
        LoadScene("App");
    }
    public void LoadScene(string sceneName)
    {
        StartCoroutine(BeginLoad(sceneName));
    }

    private IEnumerator BeginLoad(string sceneName)
    {
        yield return new WaitForSeconds(2f);
        operation = SceneManager.LoadSceneAsync(sceneName);
       
        while (!operation.isDone)
        {
            yield return null;
        }

        
        operation = null;

    }

}