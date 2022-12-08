using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _player;

    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private Spawner _spawner;
    
    private void OnEnable()
    {
        _startScreen.OnClickPlayButton += StartTrial;
        _player.OnBirdDied += OnGameOver;
        _gameOverScreen.OnClickGameOverButton += StartTrial;
    }

    private void OnDisable()
    {
        _startScreen.OnClickPlayButton -= StartTrial;
        _player.OnBirdDied -= OnGameOver;
        _gameOverScreen.OnClickGameOverButton -= StartTrial;
    }

    private void Start()
    {
        OnBeginPlay();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.gameObject.SetActive(true);
    }

    private void OnBeginPlay()
    {
        _startScreen.gameObject.SetActive(true);

        Time.timeScale = 0;

        _player.ResetBird();

    }

    private void StartTrial()
    {
        _player.ResetBird();

        _spawner.ResetSpawner();

        _startScreen.gameObject.SetActive(false);
        _gameOverScreen.gameObject.SetActive(false);

        Time.timeScale = 1;
    }
}
