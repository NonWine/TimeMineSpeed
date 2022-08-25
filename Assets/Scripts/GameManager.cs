using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager :  LEVELS
{
    public ScoreManager scoreManager;
    public Timer timer;
    public GameObject[] objs;
    bool GameHasOver = false, GameHasWon = false, condition = false;

    public void GameWin()
    {
        if(GameHasWon == false && scoreManager.score == 5)
        {
            GameHasWon = true;
            Invoke("Restart", 1f);
          
        }
    
    }
    public void GameOver()
    {
        if(GameHasOver == false && timer.timerText.text == "0")
        {
            GameHasOver = true;
            Invoke("Restart", 1f);
            
        }
    }
    void Restart()
    {
        if(GameHasWon)
        {
            for(int i=0;i< objs.Length; i++)
            {
                if (objs[i].tag == "GameWin")
                    objs[i].SetActive(true);
                if(objs[i].tag == "TextWin")
                    objs[i].GetComponent<Animation>().Play();
            }
          
            PlayerSwitcher(false);
         
        }
        else if (GameHasOver)
        {
            for (int i = 0; i < objs.Length; i++)
            {
                if (objs[i].tag == "GameOver")
                    objs[i].SetActive(true);
                if (objs[i].tag == "TextOver")
                    objs[i].GetComponent<Animation>().Play();
            }
            PlayerSwitcher(false);
            
        }
        
    }
    public void StartMenu()
    {
        SceneManager.LoadScene(0);
      
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Rules()
    {
        for(int i =0;i < objs.Length; i++)
        {
            if (objs[i].tag == "Rules" && condition == false)
            {
                objs[i].SetActive(true);
                condition = true;
            }
            else if(objs[i].tag == "Rules" && condition == true)
            {
                objs[i].SetActive(false);
                condition = false;
            }
             
        }

    }
    public void Levels()
    {
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].tag == "LEVELs" && condition == false)
            {
                objs[i].SetActive(true);
                condition = true;
            }
            else if(objs[i].tag == "LEVELs" && condition == true)
            {
                objs[i].SetActive(false);
                condition = false;
            }
        }
    }
    public void SetPause()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            for (int i = 0; i < objs.Length; i++)
            {
                if (objs[i].tag == "Pause")
                    objs[i].SetActive(true);
            }
           
            PlayerSwitcher(false);
        }

    }
    public void ReturnPause()
    {
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].tag == "Pause")
                objs[i].SetActive(false);
        }
        PlayerSwitcher(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
    
    //to turn off or turn on the player
    void PlayerSwitcher(bool switcher)
    {
       
        if (switcher == false)
        {
            Cursor.visible = true;
            timer.enabled = false;
        }

        else if(switcher == true)
        {
            Cursor.visible = false;
            timer.enabled = true;
        }
            
        for (int i=0;i < objs.Length; i++)
        {
            if(objs[i].tag == "Player")
            {
                objs[i].GetComponent<CharacterContoll>().enabled = switcher;
                objs[i].GetComponent<MouseMove>().enabled = switcher;
                objs[i].GetComponent<Interactive>().enabled = switcher;
            }
        }
    }
}