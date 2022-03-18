using Labirint.Data;

namespace Labirint.View
{
    internal sealed class TextController : IExecute
    {
        private ITextaData _textData;
        private readonly PlayerData _data;
        public void Execute(float deltaTime)
        {
            _textData.UpdateText(_data);
        }

        public TextController(PlayerData data, ITextaData textData)
        {
            _textData = textData;
            _data = data;
        }
    }
}
