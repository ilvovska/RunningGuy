using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
  [SerializeField] private Button _playButton;
  [SerializeField] private TMP_Text _text;

  public event Action OnPlayClick;

  public void Show()
  {
    _playButton.onClick.AddListener(OnPlayButtonClick);
    gameObject.SetActive(true);
  }

  public void Show(double time)
  {
    _text.text = $"{time} sec";
    _playButton.onClick.AddListener(OnPlayButtonClick);
    gameObject.SetActive(true);
  }

  private void Hide()
  {
    _playButton.onClick.RemoveListener(OnPlayButtonClick);
    gameObject.SetActive(false);
  }

  private void OnPlayButtonClick()
  {
    Hide();
    OnPlayClick?.Invoke();
  }
}
