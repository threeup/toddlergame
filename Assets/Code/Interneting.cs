using System;
using System.Text;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;


public class Interneting : MonoBehaviour, ITextureGetter
{
    private string ApiKey = "AIzaSyAf-lWK9bT4CwPdvSmHFUsKmUNIfwW0GSg";
    private string SearchID = "008820561991027430202:p9wto85prgd";

    private SearchResult searchResult;

    public TextureEvent OnMainTextureChanged;

    public TextureEvent GetTextureEvent() { return OnMainTextureChanged; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    

    public void OnWordChosen(string InWord)
    {
        StringBuilder sb = new StringBuilder("https://www.googleapis.com/customsearch/v1?key=");
        sb.Append(ApiKey);
        sb.Append("&cx=");
        sb.Append(SearchID);
        sb.Append("&num=3");
        sb.Append("&searchType=image");
        sb.Append("&q=");
        sb.Append(InWord);
        StartCoroutine(GetRequest(sb.ToString()));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                searchResult = JsonUtility.FromJson<SearchResult>(webRequest.downloadHandler.text);
                if(searchResult.items.Length > 0)
                {
                    int idx = UnityEngine.Random.Range(0, searchResult.items.Length);
                    string imgURI = searchResult.items[idx].link;
                    StartCoroutine(GetImage(imgURI));
                }
            }
        }
    }

    
    IEnumerator GetImage(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            DownloadHandlerTexture texDl = new DownloadHandlerTexture(true);
            // Request and wait for the desired page.
            webRequest.downloadHandler = texDl;
            yield return webRequest.SendWebRequest();
                
            if(!webRequest.isNetworkError && !webRequest.isHttpError) 
            {
                OnMainTextureChanged.Invoke(texDl.texture);
            }
            else
            {
                Debug.Log("Texture fail");
            }

        }
    }
}
