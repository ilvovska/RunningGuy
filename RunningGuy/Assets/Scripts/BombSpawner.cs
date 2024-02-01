class BombSpawner : Spawner<Bomb>
{
  public void StartGame()
  {
    ResetObjects();
    
    for (int i = 0; i < _gameSettings.BombCount; i++)
    {
      Spawn();
    }
  }
}