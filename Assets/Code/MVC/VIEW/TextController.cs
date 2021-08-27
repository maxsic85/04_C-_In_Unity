using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.MVC.VIEW
{
    internal sealed class TextController : IExecute
    {
        private  ITextaData _textData;
        private readonly PlayerData _data;
        public void Execute(float deltaTime)
        {
            _textData.UpdateText(_data);
        }

        public TextController(PlayerData data, ITextaData textData)
        {
           _textData=textData;
            _data = data;
        }
    }
}
