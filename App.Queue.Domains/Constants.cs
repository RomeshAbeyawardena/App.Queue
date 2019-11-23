using System;
using System.Collections.Generic;
using System.Text;

namespace App.Queue.Domains
{
    public static class Constants
    {
        #region Commands
        public const string GetQueueItems = "GetQueueItems";
        #endregion
        #region QueueItem Parameters
        public const string QueueId = "queueId";
        public const string QueueItemStatusType = "queueItemStatusType";
        #endregion
    }
}
