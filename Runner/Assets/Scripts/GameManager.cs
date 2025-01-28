using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject MainPanel;
    public GameObject FailPanel;
    public GameObject SuccPanel;
    public Image whiteImage;
    private int effectControl = 0;
    public Animator layoutAnimator;
    //Buttons
    public GameObject settings_Open;
    public GameObject settings_Close;
    public GameObject sound_On;
    public GameObject sound_Off;
    public GameObject vibration_On;
    public GameObject vibration_Off;
    public GameObject iap;
    public GameObject information;
    public GameObject intro_Hand;
    public GameObject taptomove_Text;
    public GameObject noAds;
    public GameObject shop_Button;


    public void Start()
    {
        if (PlayerPrefs.HasKey("Sound") == false)
        {
            PlayerPrefs.SetInt("Sound", 1);
        }
        if (PlayerPrefs.HasKey("Vibration") == false)
        {
            PlayerPrefs.SetInt("Vibration", 1);
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    public void StartButtonTapped()
    {
        MainPanel.gameObject.SetActive(false);
        GameObject playerSpawnerGO = GameObject.FindGameObjectWithTag("PlayerSpawner");
        PlayerSpawnerController playerSpawner = playerSpawnerGO.GetComponent<PlayerSpawnerController>();
        playerSpawner.MovePlayer();
    }
    public void ShowFailPanel()
    {
        FailPanel.gameObject.SetActive(true);
    }
    public void RestartButtonTapped()
    {
        LevelLoader.instance.GetLevel();
    }
    public void ShowSuccPanel()
    {
        SuccPanel.gameObject.SetActive(true);

    }
    public void NextLevelButtonTapped()
    {
        LevelLoader.instance.NextLevel();
 
    }
}
