using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;



public class Binding : MonoBehaviour
{
    [SerializeField] public Image CenterImage;
    [SerializeField] public Text CenterText;
    [SerializeField] public Text BelowText;

    
    [SerializeField] public Button HearButton;
    
    [SerializeField] public Button ToggleViewButton;
    
    [SerializeField] public Button MoreButton;

    [SerializeField] public ImageEvent OnCenterImageReady;
    

    [SerializeField] public TextEvent OnCenterTextReady;
    [SerializeField] public TextEvent OnBelowTextReady;
    [SerializeField] public TextureEvent OnCenterTextureReady;
    [SerializeField] public UnityEvent HearPressed;
    [SerializeField] public UnityEvent ToggleViewPressed;
    [SerializeField] public UnityEvent MorePressed;
    [SerializeField] public StringEvent OnWordReady;
    [SerializeField] public GameObject TextureGetterObject;
    [SerializeField] public GameObject WordGetterObject;

    // Start is called before the first frame update
    void Start()
    {
        OnCenterImageReady.Invoke(CenterImage);
        OnCenterTextReady.Invoke(CenterText);
        OnBelowTextReady.Invoke(BelowText);
        HearButton.onClick.AddListener(OnHearButtonClick);
        ToggleViewButton.onClick.AddListener(OnToggleViewButtonClick);
        MoreButton.onClick.AddListener(OnMoreButtonClick);


        IWordGetter RealWordGetter = WordGetterObject?.GetComponent<IWordGetter>();
        if(RealWordGetter != null)
        {
            RealWordGetter.GetWordEvent().AddListener(OnGetterWordChanged);
        }
        ITextureGetter RealTextureGetter = TextureGetterObject?.GetComponent<ITextureGetter>();
        if(RealTextureGetter != null)
        {
            RealTextureGetter.GetTextureEvent().AddListener(OnGetterTextureChanged);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHearButtonClick()
    {
        HearPressed.Invoke();
    }
    
    public void OnToggleViewButtonClick()
    {
        ToggleViewPressed.Invoke();
    }
    
    public void OnMoreButtonClick()
    {
        MorePressed.Invoke();
    }

    public void OnGetterWordChanged(string InWord)
    {
        OnWordReady.Invoke(InWord);
    }
    public void OnGetterTextureChanged(Texture2D InTexture)
    {
        OnCenterTextureReady.Invoke(InTexture);
    }
}
