using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager singleton;

    private GroundPiece[] allGroundPieces;
    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else if (singleton != null)
        {
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }
    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        SetupNewLevel();
    }

    public void CheckComplete()
    {
        bool isFinished = true;

        for(int i = 0; i < allGroundPieces.Length; i++)
        {
            if (allGroundPieces[i].isColored == false)
            {
                isFinished = false;
                break;
            }
        }

        if (isFinished)
        {
            // Next Level
            NextLevel();
        }
    }

    private void NextLevel()
    {
        // When I make 50 levels
        /*
        if (SceneManager.GetActiveScene().buildIndex == 50)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }*/
        // If maxed out levels (note: I have 4 levels right now)
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            // Load the first Scene
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }

    void Start()
    {
        SetupNewLevel();
    }
    private void SetupNewLevel()
    {
        allGroundPieces = FindObjectsOfType<GroundPiece>();
    }

    public void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
