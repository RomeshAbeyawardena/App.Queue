namespace App.Queue.Domains
{
    public static class Constants
    {
        #region General
        public const char DigestSeparator = '|';
        #endregion
        #region Commands
        public const string GetQueue = "GetQueue";
        public const string GetQueueItems = "GetQueueItems";
        #endregion
        #region Command Parameters
            #region Queue
            public const string QueueUniqueId = "queueUniqueId";
            #endregion
            #region QueueItem
            public const string QueueId = "queueId";
            public const string QueueItemStatusType = "queueItemStatusType";
            #endregion
        #endregion
    }
}
