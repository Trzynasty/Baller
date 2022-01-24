using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBricks = 0;

    void Start()
    {
        int gameCount = FindObjectsOfType<Level>().Length;
        if (gameCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadLevel(string name)
    {
        breakableBricks = 0;
        SceneManager.LoadScene(name);    
    }
	
	public void LoadNextLevel()
    {
        breakableBricks = 0;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
	}

    public void RegisterBreakableBrick()
    {
        breakableBricks++;
    }

	public void BrickDestoyed()
    {
        breakableBricks--;
        if (breakableBricks <= 0)
        {
			LoadNextLevel();
		}
	}

    public void QuitRequest()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }
}
