using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void ChangeScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
