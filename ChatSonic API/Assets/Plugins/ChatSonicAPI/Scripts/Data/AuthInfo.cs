using UnityEngine;

namespace ChatSonicAPI
{
    [CreateAssetMenu(fileName = "AuthInfo", menuName = "ChatSonicAPI/AuthInfo")]
    public class AuthInfo : ScriptableObject
    {
        [Tooltip("Copy paste api key here")]
        public string apiKey;

    }
}