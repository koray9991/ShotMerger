using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject GameOverPanel;
    public bool GameOver;
    public bool Finish;
    public GameObject FinishPanel;
    public Text FirePowerText;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        FirePowerText.text = Rush.Instance.FirePower.ToString() + " / SEC";
    }
    public void Buttons(int ButtonNo)
    {
        if (ButtonNo == 1)
        {
            SceneManager.LoadScene(Application.loadedLevel);
        }
    }
}
