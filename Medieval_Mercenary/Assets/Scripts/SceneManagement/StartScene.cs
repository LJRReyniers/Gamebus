using UnityEngine;

public class StartScene : MonoBehaviour
{
    void Start()
    {
        SceneController.Instance.loadScene(0);
    }
}
