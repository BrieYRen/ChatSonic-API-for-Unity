namespace ChatSonicAPI
{
    [System.Serializable]
    public class RequestData
    {
        public bool enable_google_results;
        public bool enable_memory;
        public string input_text;
        public HistoryData[] history_data;
    }

    [System.Serializable]
    public class HistoryData
    {
        public bool is_sent;
        public string message;
    }

}