using UnityEngine;

public class Dashboard : MonoBehaviour
{
    //[SerializeField] private SceneController _sceneController;

    public void CharacterBuilder()
    {
        SceneController.Instance.loadScene(1);
    }

    public void Level1()
    {
        SceneController.Instance.loadScene(2);
    }

    //public void Level2() { }
}
