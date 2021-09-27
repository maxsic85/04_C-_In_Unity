using UnityEngine;
namespace MAX.CODE.MVC
{
    public class TestLogController : IExecute
    {
        public void Execute(float deltaTime)
        {
            Debug.Log("TestCOntroller");
        }
    }
}
