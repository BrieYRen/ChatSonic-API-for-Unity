using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace ChatSonicAPI
{
    public class SonicAPI : MonoBehaviour
    {
        public delegate void OnSonicReply(string reply);
        public OnSonicReply onSonicReplyCallback;

        [SerializeField, Tooltip("Drag drop AuthInfo config file here")]
        AuthInfo authInfo;

        [SerializeField, Tooltip("Drag drop CompletionSettings config file here")]
        CompletionSettings completionSettings;

        List<HistoryData> historyDataList = new List<HistoryData>();


        public IEnumerator AskChatSonic(string inputString)
        {
            if (!completionSettings.enableMemory)
                historyDataList.Clear();

            RequestData requestData = new RequestData
            {
                enable_google_results = completionSettings.enableGoogle,
                enable_memory = completionSettings.enableMemory,
                input_text = inputString,
                history_data = historyDataList.ToArray()
            };

            string apiKey = authInfo.apiKey;

            string jsonData = JsonUtility.ToJson(requestData);
            byte[] postData = System.Text.Encoding.UTF8.GetBytes(jsonData);

            UploadHandler uploadHandler = new UploadHandlerRaw(postData);
            DownloadHandler downloadHandler = new DownloadHandlerBuffer();

            using (UnityWebRequest request = new UnityWebRequest(completionSettings.Url, UnityWebRequest.kHttpVerbPOST, downloadHandler, uploadHandler))
            {
                request.SetRequestHeader("accept", "application/json");
                request.SetRequestHeader("content-type", "application/json");
                request.SetRequestHeader("X-API-KEY", apiKey);

                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    ResponseData responseData = JsonUtility.FromJson<ResponseData>(request.downloadHandler.text);
                    string answerString = responseData.message;

                    if (completionSettings.enableMemory)
                    {
                        HistoryData requestHistory = new HistoryData { is_sent = true, message = inputString };
                        historyDataList.Add(requestHistory);
                        HistoryData responseHistory = new HistoryData { is_sent = false, message = answerString };
                        historyDataList.Add(responseHistory);
                    }

                    if (onSonicReplyCallback != null)
                        onSonicReplyCallback.Invoke(answerString);
                }
                else
                {
                    if (onSonicReplyCallback != null)
                        onSonicReplyCallback.Invoke(request.error);
                }
            }
        }
    }
}