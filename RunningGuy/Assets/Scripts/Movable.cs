using UnityEngine;

public abstract class Movable : MonoBehaviour
{
  protected virtual float Speed { get; }

  protected void Move(Vector3 direction, Vector2 size)
  {
    var currentPosition = transform.position;
    var speedDirection = direction.normalized * (Speed * Time.deltaTime);
    var newPosition = new Vector3(
      Mathf.Clamp(currentPosition.x + speedDirection.x, -size.x, size.x),
      currentPosition.y,
      Mathf.Clamp(currentPosition.z + speedDirection.z, -size.y, size.y));

    transform.position = newPosition;
  }
}
