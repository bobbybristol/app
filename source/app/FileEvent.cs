
namespace app
{
    public class FileEvent
    {
        private string[] FileEvents;
       public FileEvent(params string[] fileEvents )
       {
           this.FileEvents = fileEvents;
       }
        public void Process()
        {
            foreach(string fileEvent in FileEvents)
            {
                
            }
        }

        public  void CheckEvent(string fileEvent)
        {

        }

    }
}