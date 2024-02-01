using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
  [SerializeField] private InputSystem _inputSystem;
  [SerializeField] private GameSettings _gameSettings;
  [SerializeField] private GameController _gameController;
  [SerializeField] private MenuController _menuController;
  
  public override void InstallBindings()
  {
    Container.Bind<InputSystem>().FromInstance(_inputSystem);
    Container.Bind<GameSettings>().FromInstance(_gameSettings);
    Container.Bind<GameController>().FromInstance(_gameController);
    Container.Bind<MenuController>().FromInstance(_menuController);
  }
}