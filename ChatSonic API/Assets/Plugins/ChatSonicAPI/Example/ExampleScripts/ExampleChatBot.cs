using UnityEngine;
using UnityEngine.UI;
using ChatSonicAPI;

[RequireComponent(typeof(SonicAPI))]
public class ExampleChatBot : MonoBehaviour
{
    [SerializeField, Tooltip("Drag drop input ui text here")]
    Text inputText;

    [SerializeField, Tooltip("Drag drop output ui text here")]
    Text outputText;

    SonicAPI sonicAPI;


    private void Start()
    {
        sonicAPI = GetComponent<SonicAPI>();
        sonicAPI.onSonicReplyCallback += UpdateReply;
    }

    public void AskSonic()
    {
        StartCoroutine(sonicAPI.AskChatSonic(inputText.text));
    }

    void UpdateReply(string replyString)
    {
        outputText.text = replyString;
    }
}
