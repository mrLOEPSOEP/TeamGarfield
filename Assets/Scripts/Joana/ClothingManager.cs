using UnityEngine;

public class ClothingManager : MonoBehaviour, IAmXRObserver<SafetyData>
{
    public static ClothingManager Instance { get; private set; }
    
    [SerializeField] SafetySocketSubject jumpSuitSocket;    
    [SerializeField] SafetySocketSubject safetyGlassesSocket;
    [SerializeField] SafetySocketSubject safetyShoesSocket;
    [SerializeField] SafetySocketSubject safetyGloveLeft;
    [SerializeField] SafetySocketSubject safetyGloveRight;
    
    [Header("DrillRoomTeleport")]
    [SerializeField] GameObject TeleportPosition;
    [SerializeField] GameObject player;

    public bool jumpsuit { get; private set; }
    public bool safetyGlasses { get; private set; }
    public bool safetyShoes { get; private set; }


    void Start()
    {
        //Formatted like this to keep the code more confined. this does the same as going under it every line adds one observer
        if (jumpSuitSocket != null)         {jumpSuitSocket.AddObserver(this);}
        if (safetyGlassesSocket != null)    {safetyGlassesSocket.AddObserver(this);}
        if (safetyShoesSocket != null)      {safetyShoesSocket.AddObserver(this);}
        if (safetyGloveLeft != null)        {safetyGloveLeft.AddObserver(this);}
        if (safetyGloveRight != null)       {safetyGloveRight.AddObserver(this);}
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
        if (sender == jumpSuitSocket)
        {
            jumpsuit = data.isPresent;
        }
        
        if (sender == safetyGlassesSocket)
        {
            safetyGlasses = data.isPresent;   
        }

        if (sender == safetyShoesSocket)
        {
            safetyShoes = data.isPresent;
        }

        HasForbiddenClothes();
        //Check if all conditions are met
        if (HasAllRequiredClothing())
        {
            TeleportToDrillingRoom();
            Debug.Log("all conditions met");
        }
    }
    public void EquipSafetyGlasses()
    {
        safetyGlasses = true;
    }

    public void EquipJumpsuit()
    {
        jumpsuit = true;
    }

    public void EquipSafetyShoes()
    {
        safetyShoes = true;
    }

    public bool HasAllRequiredClothing()
    {
        //If a socket is assigned we check the value otherwise treat it as true
        bool glassesCheck = (safetyGlassesSocket == null) || safetyGlasses;
        bool jumpsuitCheck = (jumpSuitSocket == null) || jumpsuit;
        bool shoesCheck = (safetyShoesSocket == null) || safetyShoes;

        bool noForbiddenItemsPresent = !HasForbiddenClothes();


        return glassesCheck && jumpsuitCheck && shoesCheck;
    }

    bool HasForbiddenClothes()
    {
        bool glovesCheckLeft = (safetyGloveLeft == null) && safetyGloveLeft;
        bool glovesCheckRight = (safetyGloveRight == null) && safetyGloveRight;

        return glovesCheckLeft || glovesCheckRight;
    }

    void TeleportToDrillingRoom()
    {
        player.transform.position = TeleportPosition.transform.position;
    }
}