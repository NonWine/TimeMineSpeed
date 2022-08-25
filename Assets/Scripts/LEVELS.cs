using UnityEngine;
using UnityEngine.SceneManagement;
public class LEVELS : MonoBehaviour
{
    public GameObject Panel,RulePanel;
    bool swtch = false;
    //load first level
    public void LevelFirst()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //load second level
    public void LevelSecond()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    //load third level
    public void LevelThird()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
}
