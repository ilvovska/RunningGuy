using UnityEngine;

public class Enemy : Movable
{
  private GameSettings _gameSettings;
  private Transform _target;

  protected override float Speed => _gameSettings.EnemySpeed;

  private void Update()
  {
    if (_target == null)
      return;
    
    Move(_target.position - transform.position, _gameSettings.FieldSize);
  }

  public void Init(GameSettings gameSettings, Transform target)
  {
    _gameSettings = gameSettings;
    _target = target;
  }
}
