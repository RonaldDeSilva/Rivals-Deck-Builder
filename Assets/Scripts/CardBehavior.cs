using UnityEngine;

public class CardBehavior : MonoBehaviour
{
    private bool FollowMouse = false;
    private GameObject Discard;
    private Rigidbody rb;
    public bool OverHand = true;
    private bool RunOnce = false;
    private float YVal = 50.0f;
    public string Effect;
    private CardDirectory CardEffects;
    public int APCost;
    private GameController GameController;
    public bool IsTargetable;
    public bool IsCreature;

    void Start()
    {
        Discard = GameObject.Find("Discard");
        rb = GetComponent<Rigidbody>();
        CardEffects = GameObject.FindGameObjectWithTag("GameController").GetComponent<CardDirectory>();
        GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        //This function mainly makes sure that the card follows the mouse cursor
        if (FollowMouse)
        {
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z - 5));
            rb.position = mouseWorldPos;
            if (!RunOnce)
            {
                //The YVal variable is set when the cards are initially picked up
                //It is important as it is required for determining whether a card should be played,
                //or if it should be put back in the hand
                YVal = transform.position.y;
                RunOnce = true;
            }
        }
        else if (transform.parent.name != "Deck")
        {
            transform.localPosition = new Vector3(0, 0, 0);
            transform.localRotation = new Quaternion(0, 0, 0, transform.rotation.w);
        }
    }

    private void OnMouseDown()
    {
        //This function is used to determine what happens when a player clicks on a card,
        //Either the card is sent back to the Hand, or it is played and the card is sent to discard
        if (transform.parent.name == "Position 1" || transform.parent.name == "Position 2" || transform.parent.name == "Position 3" || transform.parent.name == "Position 4" || transform.parent.name == "Position 5")
        {
            if (FollowMouse)
            {
                FollowMouse = false;
                RunOnce = false;
                if (transform.position.y >= YVal + 2f && APCost <= GameController.PlayerCurrentAP)
                {
                    GameController.PlayerCurrentAP -= APCost;
                    CardEffects.UseCard(Effect, true);
                    transform.parent = Discard.transform;
                }
            }
            else if (!IsTargetable && !IsCreature)
            {
                FollowMouse = true;
            }
            else if (IsCreature && GameController.PlayerOpenSlots > 0)
            {
                CardEffects.SummonCreature(this.gameObject, Effect);
            }
            else if (IsTargetable)
            {

            }
        }
    }
}
