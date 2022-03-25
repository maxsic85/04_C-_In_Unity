using UnityEngine;

namespace Labirint.Core
{
    public sealed class PCInput : IPCKeybordInput
    {
      private readonly  InputData _inputData;

        public PCInput(InputData inputData)
        {
            _inputData = inputData;
        }

        public void GetAxis()
        {
            GetAxisFire();
            GetAxisHorizontal();
            GetAxisVertical();
        }
        public bool GetAxisFire()
        {
            return Input.GetKeyUp(_inputData.FireAxis);
        }
        public float GetAxisHorizontal()
        {
            return Input.GetAxis(_inputData.HorizontalAxis);
        }
        public float GetAxisVertical()
        {
            return -Input.GetAxis(_inputData.VerticalAxis);
        }
        public bool GetSave()
        {
            return Input.GetKeyDown(_inputData.SavePlayer);
        }
        public bool GetLoad()
        {
            return Input.GetKeyDown(_inputData.LoadPlayer);
        }

    }
}