using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

namespace PTexto
{
    public class TextPetitioner : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private TextMeshProUGUI outputText;
    
        private static string apiUrl = "http://gpu1.esit.ull.es:4000/v1/chat/completions";
    
        [System.Serializable]
        public class ChatMessage
        {
            public string content;
            public string role;
        }

        [System.Serializable]
        public class ChatChoice
        {
            public int index;
            public string finish_reason;
            public ChatMessage message;
        }

        [System.Serializable]
        public class ChatResponse
        {
            public ChatChoice[] choices;
        }
    
        public void OnSendButtonClicked()
        {
            string userInput = inputField.text;
            StartCoroutine(SendMessageToChatbot(userInput));
        }
    
        public void SendMessageFromString(string message)
        {
            StartCoroutine(SendMessageToChatbot(message));
        }
    
        private IEnumerator SendMessageToChatbot(string message)
        {
            Debug.Log("Entering send message function");
            string jsonPayload = "{"
                                 + "\"model\": \"ollama/llama3.1:8b\"," // Debe coincidir con el modelo cargado en Ollama
                                 + "\"messages\": [{\"role\": \"user\", \"content\": \"" + message + "\"}]"
                                 + "}";
            Debug.Log(jsonPayload);
            UnityWebRequest request = new UnityWebRequest(apiUrl, "POST");
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonPayload);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "Bearer sk-1234");
            yield return request.SendWebRequest();
            Debug.Log("Petition Sent");
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error al conectar con el chatbot: " + request.error);
            }
            else
            {
                string jsonResponse = request.downloadHandler.text;
                Debug.Log("Respuesta de la IA: " + jsonResponse);
                var parsed = JsonUtility.FromJson<ChatResponse>(jsonResponse);
                if (parsed != null && parsed.choices != null && parsed.choices.Length > 0 && parsed.choices[0].message != null)
                {
                    outputText.text = parsed.choices[0].message.content;
                }
                else
                {
                    outputText.text = jsonResponse;
                }
            }
        }

    }
}
