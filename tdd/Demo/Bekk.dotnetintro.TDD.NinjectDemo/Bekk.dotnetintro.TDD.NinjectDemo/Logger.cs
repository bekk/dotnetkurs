namespace Bekk.dotnetintro.TDD.NinjectDemo
{
    public class Logger
    {
        private readonly IOutput _output;

        public Logger(IOutput output)
        {
            _output = output;
        }

        public void Start()
        {
            _output.Write("Starting logger");
        }
    }
}
