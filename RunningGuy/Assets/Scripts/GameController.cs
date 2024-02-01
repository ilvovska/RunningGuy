using System;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
  [Inject] private InputSystem _inputSystem;
  [Inject] private MenuController _menuController;

  [SerializeField] private Player _player;
  [SerializeField] private EnemySpawner _enemySpawner;
  [SerializeField] private BombSpawner _bombSpawner;

  private long _startTime;

  public Transform Player => _player.transform;

  private void Start()
  {
    _inputSystem.Enable(false);
    _menuController.GameMenu.OnPlayClick += OnStartGameClick;
    _menuController.GameMenu.Show();
  }

  private void OnStartGameClick()
  {
    _menuController.GameMenu.OnPlayClick -= OnStartGameClick;
    StartGame();
    _player.OnDeath += OnPlayerDeath;
    _startTime = DateTime.Now.Ticks;
  }

  private void OnPlayerDeath()
  {
    _player.OnDeath -= OnPlayerDeath;
    EndGame();
    _menuController.GameMenu.OnPlayClick += OnStartGameClick;
    _menuController.GameMenu.Show(CalculateGameTime(_startTime));
  }

  private void StartGame()
  {
    _bombSpawner.StartGame();
    _enemySpawner.StartGame(_player.transform);
    _inputSystem.Enable(true);
    _player.Reset();
  }

  private void EndGame()
  {
    _inputSystem.Enable(false);
    _enemySpawner.StopGame();
  }

  private static double CalculateGameTime(long startTime)
  {
    var ticks = DateTime.Now.Ticks - startTime;
    TimeSpan timeSpan = TimeSpan.FromTicks(ticks);
    return Math.Round(timeSpan.TotalSeconds, 2);
  }
}