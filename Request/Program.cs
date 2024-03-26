namespace Request
{
    internal class Request
    {
        public class gameGroup
        {

        }
        public gameGroup GameGroup { get; set; }

        public Request (gameGroup gameGroup )
        {
            GameGroup = gameGroup;
        }
    }
}
