namespace Labirint.Core
{
    public interface IPCKeybordInput :IInput
    {
        public float GetAxisHorizontal();
        public float GetAxisVertical();
        public bool GetAxisFire();

    }
}