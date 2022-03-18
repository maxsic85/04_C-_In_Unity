namespace Labirint.Core
{
    public sealed class InputController
    {
        private readonly IPCKeybordInput _input;
        public InputController(IPCKeybordInput input)
        {
            _input = input;
        }

        public bool GetFire()
        {
          return  _input.GetAxisFire();
        }

        public (float x,float z) GetAxisForMove()
        {
            var result = (x: _input.GetAxisHorizontal(), z: _input.GetAxisVertical());
            return result;
        }

        public (bool isSave, bool isLoad)  GetSave()
        {
            var result = (isSave: _input.GetSave(), isLoad: _input.GetLoad());
            return result;
        }
    }
}