using System.Threading;

namespace StoppUhr.Model
{
    public class StoppUhr
    {
     

        public StoppUhr()
        {
          

            System.Threading.Tasks.Task.Run(GetriebemotorTask);
        }
        private void GetriebemotorTask()
        {
            while (true)
            {
             

                Thread.Sleep(10);
            }
            // ReSharper disable once FunctionNeverReturns
        }
    }
}