using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
  [Inject] protected GameSettings _gameSettings;

  [SerializeField] protected T _object;

  private readonly List<T> _pool = new List<T>();
  private int _spawnedCount = 0;

  protected void ResetObjects()
  {
    _spawnedCount = 0;
    foreach (var spawnedObject in _pool)
    {
      spawnedObject.gameObject.SetActive(false);
    }
  }

  protected T Spawn()
  {
    T newObject;
    if (_pool.Count > _spawnedCount)
    {
      newObject = _pool[_spawnedCount];
      newObject.gameObject.SetActive(true);
    }
    else
    {
      newObject = Instantiate(_object, transform);
      _pool.Add(newObject);
    }

    newObject.transform.localPosition = RandomPoint();
    _spawnedCount++;
    return newObject;
  }

  private Vector3 RandomPoint()
  {
    float x = Random.Range(-_gameSettings.FieldSize.x, _gameSettings.FieldSize.x);
    float y = Random.Range(-_gameSettings.FieldSize.y, _gameSettings.FieldSize.y);

    return new Vector3(x,0, y);
  }
}