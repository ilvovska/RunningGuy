using System.Collections;
using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
  private bool _isSpawning;
  private Coroutine _spawningCoroutine;
  
  public void StartGame(Transform target)
  {
    ResetObjects();
    _isSpawning = true;
    _spawningCoroutine = StartCoroutine(SpawnCoroutine(target));
  }
  
  public void StopGame()
  {
    StopCoroutine(_spawningCoroutine);
    _isSpawning = false;
  }

  private IEnumerator SpawnCoroutine(Transform target)
  {
    while (_isSpawning)
    {
      var enemy = Spawn();
      enemy.Init(_gameSettings, target);
      yield return new WaitForSeconds(_gameSettings.EnemySpawnCooldown);
    }
  }
}