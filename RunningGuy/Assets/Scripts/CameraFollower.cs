using UnityEngine;
using Zenject;

public class CameraFollower : MonoBehaviour
{
  [Inject] private GameController _gameController;

  private Transform _target;
  private Vector3 _offset;

  void Start()
  {
    _target = _gameController.Player;

    if (_target != null)
      _offset = transform.position - _target.position;
  }

  void Update()
  {
    if (_target == null) return;

    Vector3 newPosition = _target.position + _offset;
    transform.position = newPosition;
  }
}