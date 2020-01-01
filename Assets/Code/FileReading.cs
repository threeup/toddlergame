using System.IO;
using System.Collections.Generic;
using UnityEngine;



public class FileReading : MonoBehaviour, IWordGetter
{
    private string FileName = "words";
    public StringEvent WordEvent;
    public StringEvent GetWordEvent() { return WordEvent; }

    public List<string> words;

    void Start()
    {
        TextAsset wordData = Resources.Load(FileName, typeof(TextAsset)) as TextAsset;
        using(StringReader reader = new StringReader(wordData.text))
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                string[] lineWords = line.Split();
                foreach(string word in lineWords)
                {
                    if(word.Length > 0)
                    {
                        words.Add(word);
                    }
                }
                line = reader.ReadLine();
            }
        }
    }
    public void RequestWord()
    {
        if(words.Count > 0)
        {
            int idx = Random.Range(0, words.Count);
            WordEvent.Invoke(words[idx]);    
        }
        
    }
}
