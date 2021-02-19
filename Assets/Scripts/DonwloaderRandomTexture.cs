using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DonwloaderRandomTexture : MonoBehaviour
{
    private string _url = "https://picsum.photos/200/150";
    private Texture _texture;
    private RawImage _logo;

    private IEnumerator LoadRandomTextureFromServer()
    {
        var request = UnityWebRequestTexture.GetTexture(_url);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError ||
            request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogErrorFormat("error request [{0}, {1}]", _url, request.error);
        }
        else
        {
            _texture = DownloadHandlerTexture.GetContent(request);
            _logo.texture = _texture;
        }

        request.Dispose();
    }

    private void Start()
    {
        _logo = GetComponent<RawImage>();
        StartCoroutine(nameof(LoadRandomTextureFromServer));
    }
}