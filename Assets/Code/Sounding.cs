using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounding : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip nextClip;
    public string soundPrefix = "Sounds/En-us-";
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    public void ChangeText(string InWord)
    {
        nextClip = Resources.Load<AudioClip>(soundPrefix+InWord);
    }

    public void PlaySound()
    {
        audioClip = nextClip;
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
