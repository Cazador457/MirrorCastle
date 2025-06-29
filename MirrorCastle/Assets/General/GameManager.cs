using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Silver playerData;
    public bool isGamePaused = false;
    public bool isInventory = false;

    private void Awake()
    {
        //GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        //PlayerData
        if (playerData == null)
        {
            playerData = new Silver();
        }
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            WinPause();
        }
        if (Input.GetKeyUp(KeyCode.I))
        {
            WinInventory();
        }
    }
    //[Menu Contoller]
    public void WinPause()
    {
        isGamePaused = !isGamePaused;
        Time.timeScale=isGamePaused ? 1 : 0;
    }
    public void WinInventory()
    {
        isInventory = !isInventory;
        Time.timeScale = isInventory ? 1 : 0;
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    //[Player Data Controller]
    public void SaveGame()
    {
        PlayerPrefs.SetFloat("Health", playerData.health);
        Debug.Log("JuegoGuardado");
    }
    public void LoadGame()
    {
        playerData.health = PlayerPrefs.GetFloat("Health", 100);
        Debug.Log("JuegoCargado");
    }
}
