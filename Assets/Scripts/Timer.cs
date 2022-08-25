using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float TimeStart = 60f;
    public Text timerText;
    void Start()
    {
        timerText.text = timerText.ToString();
    }
    
    // Update is called once per frame
    void Update()
    {
        TimeStart -= Time.deltaTime;
        timerText.text = Mathf.Round(TimeStart).ToString();
    }
}
