using System;
using UnityEngine;
using Zenject;

public class Player : Movable
{
  [Inject] private InputSystem _inputSystem;
  [Inject] private GameSettings _gameSettings;

  public event Action OnDeath;

  private bool _isRunning;

  protected override float Speed => _gameSettings.PlayerSpeed;

  private void Update()
  {
    if (_inputSystem.Direction.magnitude == 0)
      return;
    
    Move(new Vector3(_inputSystem.Direction.x,0,_inputSystem.Direction.y), _gameSettings.FieldSize);
  }

  public void Reset()
  {
    transform.localPosition = Vector3.zero;
  }

  private void OnCollisionEnter(Collision other)
  {
    OnDeath?.Invoke();
  }
}
