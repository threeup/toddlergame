using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Displaying : MonoBehaviour
{
    private Image CenterImage;
    private Text CenterText;
    private Text BelowText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BindCenterImage(Image InImage)
    {
        CenterImage = InImage;
    }
    
    public void ChangeText(string InWord)
    {
        CenterText.text = InWord;
        BelowText.text = InWord;
    }

    public void ChangeCenterTexture(Texture2D InTexture)
    {
        if(CenterImage)
        {
            Rect texRect = new Rect(0, 0, InTexture.width, InTexture.height);
            CenterImage.sprite = Sprite.Create(InTexture, texRect, Vector2.zero, 1f);
        }   
    }
    public void BindCenterText(Text InText)
    {
        CenterText = InText;
        CenterText.text = "Bound A";
    }
    
    public void BindBelowText(Text InText)
    {
        BelowText = InText;
        BelowText.text = "Bound 2";
    }

    public void ToggleView()
    {
        bool bBigImage = CenterText.enabled;
        CenterText.enabled = !bBigImage;
        CenterImage.enabled = bBigImage;
        BelowText.enabled = bBigImage;
    }
}
