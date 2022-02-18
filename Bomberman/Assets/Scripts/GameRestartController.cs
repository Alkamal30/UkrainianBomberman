using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestartController : MonoBehaviour {

    [SerializeField] private GameObject _restartPanel;


    public void ShowRestartPanel() {
        _restartPanel.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene("Scenes/MainScene");
    }
}
