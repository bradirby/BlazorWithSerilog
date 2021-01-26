using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWithSerilog.Shared
{
    public class LogHistory : ILogHistory
    {
        public bool Enabled { get; set; } = true;
        public int MaxHistoryToKeep { get; set; }

        private Queue<string> History = new Queue<string>();

        public LogHistory(IMessageLogConfiguration cfg)
        {
            MaxHistoryToKeep = cfg.MaxHistoryToKeep;
        }

        public void RecordHistory(string msg)
        {
            if (!Enabled) return;
            History.Enqueue( msg);
            if (History.Count > MaxHistoryToKeep) History.Dequeue();
        }

 
        public List<string> GetHistory()
        {
            return History.ToList();
        }
    }

    public interface ILogHistory
    {
        bool Enabled { get; set; }
         int MaxHistoryToKeep { get; set; }
        void RecordHistory(string msg);
        List<string> GetHistory();
    }
}
