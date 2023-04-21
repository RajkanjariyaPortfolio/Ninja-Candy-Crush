using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
	public GameObject pausePanel;
	private Board board;
	public bool paused = false;
	public Image soundButton;
	public Sprite musicOnsprite;
	public Sprite musicOffsprite;

    // Start is called before the first frame update
    void Start()
    {
    	if(PlayerPrefs.HasKey("Sound"))
    	{
    		if(PlayerPrefs.GetInt("Sound") == 0)
    		{
    			soundButton.sprite = musicOffsprite;
    		}
    		else
    		{
    			soundButton.sprite = musicOnsprite;
    		}
    	}
    	else
    	{
    		soundButton.sprite = musicOnsprite;
    	}
		pausePanel.SetActive(false);
        board = GameObject.FindWithTag("Board").GetComponent<Board>();
    }

    // Update is called once per frame
    void Update()
    {
        if(paused && !pausePanel.activeInHierarchy)
		{
			pausePanel.SetActive(true);
			board.currentState = GameState.pause;
		}
		if(!paused && pausePanel.activeInHierarchy)
		{
			pausePanel.SetActive(false);
			board.currentState = GameState.move;
		}
    }	

    public void Sound()
    {
    	if(PlayerPrefs.HasKey("Sound"))
    	{
    		if(PlayerPrefs.GetInt("Sound") == 0)
    		{
    			soundButton.sprite = musicOnsprite;
    			PlayerPrefs.SetInt("Sound",1);
    		}
    		else
    		{
    			soundButton.sprite = musicOffsprite;
    			PlayerPrefs.SetInt("Sound",0);
    		}
    	}
    	else
    	{
    		soundButton.sprite = musicOnsprite;
    		PlayerPrefs.SetInt("Sound",1);
    	}
    }
	
	public void PauseGame()
	{ 
		paused = !paused;
	}

	public void ExitGame()
	{
		SceneManager.LoadScene("Splash");
	}	
}
