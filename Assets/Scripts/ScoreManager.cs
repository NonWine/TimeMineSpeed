using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    // this score will increase when gold will be destroyed
    public int score =0;

    void Update()
    {
        //convert our int value in string value
        gameObject.GetComponent<Text>().text = score.ToString();
      
    }
}
