using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; private set; }
    [SerializeField] private float _sceneFadeDuration;
    private SceneFade _sceneFade;

    private void Awake()
    {
        _sceneFade = GetComponentInChildren<SceneFade>();

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("SceneController initialized");
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            Debug.LogWarning("Duplicate SceneController destroyed");
        }
    }

    private IEnumerator Start()
    {
        yield return _sceneFade.FadeInCoroutine(_sceneFadeDuration);
    }

    public void loadScene(int index)
    {
        StartCoroutine(LoadSceneByIndex(index));
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"Scene loaded: {scene.name}");
        StartCoroutine(Start());
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private IEnumerator LoadSceneByIndex(int index)
    {
        yield return _sceneFade.FadeOutCoroutine(_sceneFadeDuration);
        yield return SceneManager.LoadSceneAsync(index);
    }

    public string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
}
