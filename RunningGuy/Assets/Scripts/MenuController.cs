using UnityEngine;

public class MenuController : MonoBehaviour
{
  [SerializeField] private GameMenu _gameMenu;

  public GameMenu GameMenu => _gameMenu;
}
