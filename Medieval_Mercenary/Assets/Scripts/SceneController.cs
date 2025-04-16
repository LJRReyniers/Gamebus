using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    //[SerializeField] Animator transitionAnim;

    /*private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }*/

    public void NextScene()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        //transitionAnim.SetTrigger("End");
        //yield return new WaitForSeconds(1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        //transitionAnim.SetTrigger("Start");

        yield return 0;
    }

    public void loadScene(int index)
    {
        StartCoroutine(LoadSceneByIndex(index));
    }

    IEnumerator LoadSceneByIndex(int index)
    {
        //transitionAnim.SetTrigger("End");
        //yield return new WaitForSeconds(1);

        SceneManager.LoadScene(index);

        //transitionAnim.SetTrigger("Start");

        yield return 0;
    }
}
