using UnityEngine;

public class InputSystem : MonoBehaviour
{
   [SerializeField] private FloatingJoystick _joystick;

   public Vector2 Direction => _joystick.Direction;

   public void Enable(bool enable)
   {
      _joystick.gameObject.SetActive(enable);
      
      if(!enable)
         _joystick.OnPointerUp(null);
   }
}
