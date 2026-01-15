using UnityEngine;

public class ClothingManager : MonoBehaviour, IAmXRObserver<SafetyData>
{
    public static ClothingManager Instance { get; private set; }
    
    [SerializeField] SafetySocketSubject jumpSuitSocket;    
    [SerializeField] SafetySocketSubject safetyGlassesSocket;
    [SerializeField] SafetySocketSubject safetyShoesSocketLeft;
    [SerializeField] SafetySocketSubject safetyShoesSocketRight;
    [SerializeField] SafetySocketSubject safetyGloveLeft;
    [SerializeField] SafetySocketSubject safetyGloveRight;
    [SerializeField] SafetySocketSubject phoneSocket;
    
    [Header("DrillRoomTeleport")]
    [SerializeField] GameObject TeleportPosition;
    [SerializeField] GameObject player;

    public bool jumpsuit { get; private set; }
    public bool safetyGlasses { get; private set; }
    public bool safetyShoeLeft { get; private set; }
    public bool safetyShoeRight { get; private set; }
    public bool leftGlove { get; private set; }
    public bool rightGlove { get; private set; }
    public bool phone { get; private set; }

    void Start()
    {
        //Formatted like this to keep the code more confined. this does the same as going under it every line adds one observer
        if (jumpSuitSocket != null)         {jumpSuitSocket.AddObserver(this);}
        if (safetyGlassesSocket != null)    {safetyGlassesSocket.AddObserver(this);}
        if (safetyShoesSocketLeft != null)      {safetyShoesSocketLeft.AddObserver(this);}
        if (safetyShoesSocketRight != null)      {safetyShoesSocketRight.AddObserver(this);}
        if (safetyGloveLeft != null)        {safetyGloveLeft.AddObserver(this);}
        if (safetyGloveRight != null)       {safetyGloveRight.AddObserver(this);}
        if (phoneSocket != null)            {phoneSocket.AddObserver(this);}
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void OnNotify(XRSubject<SafetyData> sender, SafetyData data)
    {
        //Track things that have to be there
        if (sender == jumpSuitSocket) jumpsuit = data.isPresent;
        if (sender == safetyGlassesSocket) safetyGlasses = data.isPresent;
        if (sender == safetyShoesSocketLeft) safetyShoeLeft = data.isPresent;
        if (sender == safetyShoesSocketRight) safetyShoeRight = data.isPresent;

        //Track the things that may not be there
        if (sender == safetyGloveLeft) leftGlove = data.isPresent;
        if (sender == safetyGloveRight) rightGlove = data.isPresent;
        if (sender == phoneSocket)      phone = data.isPresent;

        //Check if all conditions are met
        if (HasForbiddenClothes() == false)
            {
                if (HasAllRequiredClothing())
                {
                    TeleportToDrillingRoom();
                    Debug.Log("all conditions met");
                }
            }
        Debug.Log("has forbidden clothes: " + HasForbiddenClothes());
        Debug.Log("has required clothes: " + HasAllRequiredClothing());
        
    }
    public bool HasAllRequiredClothing()
    {
        //If a socket is assigned we check the value otherwise treat it as true
        bool glassesCheck = (safetyGlassesSocket == null) || safetyGlasses;
        bool jumpsuitCheck = (jumpSuitSocket == null) || jumpsuit;
        bool shoesCheckLeft = (safetyShoesSocketLeft == null) || safetyShoeLeft;
        bool shoesCheckRight = (safetyShoesSocketRight == null) || safetyShoeRight;

        bool noForbiddenItemsPresent = HasForbiddenClothes();
        Debug.Log(noForbiddenItemsPresent);


        return glassesCheck && jumpsuitCheck && shoesCheckLeft && shoesCheckRight;
    }

    bool HasForbiddenClothes()
    {
        bool glovesCheckLeft = (safetyGloveLeft != null) || leftGlove;
        bool glovesCheckRight = (safetyGloveRight != null) || rightGlove;
        bool phoneCheck = (phoneSocket != null) || phone;

        return glovesCheckLeft || glovesCheckRight || phoneCheck;
    }

    void TeleportToDrillingRoom()
    {
        player.transform.position = TeleportPosition.transform.position;
    }
}