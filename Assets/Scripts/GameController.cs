using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    //---------The GameController Script is used to keep track of important values,-----------------//
    //---------as well as make sure all of the cards are moved to the proper piles and such.--------//
    //---------It also runs the turns system, and Creature attacks.---------------------------------//
    
    //Game Objects that are needed for GameController to function
    private GameObject Deck;
    public GameObject Discard;
    private GameObject Canvas;
    private GameObject EnemyDeck;
    private GameObject EnemyDiscard;

    //Variables relating to the players (And enemy's) Hand
    public int HandSize;
    public bool EmptyHand = true;
    public bool Refresh = false;
    public bool EnemyEmptyHand = true;
    public bool EnemyRefresh = false;
    public bool PlayersTurn = true;

    //Positions of the cards when they are in your hand
    private GameObject Position1;
    private GameObject Position2;
    private GameObject Position3;
    private GameObject Position4;
    private GameObject Position5;

    //Variables relating to Player and enemy constants
    public int PlayerAPPerTurn;
    public int EnemyAPPerTurn;
    public int PlayerHealth;
    public int EnemyHealth;
    public int PlayerMaxOpenSlots = 4;
    public int EnemyMaxOpenSlots = 4;

    //Variables relating to current status of Player and Enemy Stats
    public int PlayerCurrentAP;
    public int EnemyCurrentAP;
    public int PlayerCurrentHealth;
    public int EnemyCurrentHealth;
    public int PlayerOpenSlots;
    public int EnemyOpenSlots;

    //Creature spots for each side
    public GameObject PlayerTopSlot1;
    public GameObject PlayerTopSlot2;
    public GameObject PlayerBottomSlot1;
    public GameObject PlayerBottomSlot2;
    public GameObject EnemyTopSlot1;
    public GameObject EnemyTopSlot2;
    public GameObject EnemyBottomSlot1;
    public GameObject EnemyBottomSlot2;




    void Start()
    {
        //Finding all of the necessary Game Objects
        Deck = GameObject.Find("Deck");
        Discard = GameObject.Find("Discard");
        Canvas = GameObject.Find("Canvas");
        EnemyDeck = GameObject.Find("EnemyDeck");
        EnemyDiscard = GameObject.Find("EnemyDiscard");
        Position1 = GameObject.Find("Position 1");
        Position2 = GameObject.Find("Position 2");
        Position3 = GameObject.Find("Position 3");
        Position4 = GameObject.Find("Position 4");
        Position5 = GameObject.Find("Position 5");
    }

    void FixedUpdate()
    {
        //These If statements are for checking to see if the hand is empty and if so replacing the hand when the player has run out of cards
        if (!EmptyHand && !Refresh && PlayersTurn)
        {
            if (Position1.transform.childCount == 0 && Position2.transform.childCount == 0 && Position3.transform.childCount == 0 && Position4.transform.childCount == 0 && Position5.transform.childCount == 0)
            {
                EmptyHand = true;
            }
        }
        else if (EmptyHand && !Refresh && PlayersTurn)
        {
            Refresh = true;
            DrawCardsToHand();
        }
        else if (!EnemyEmptyHand && !EnemyRefresh && !PlayersTurn)
        {
            if (Position1.transform.childCount == 0 && Position2.transform.childCount == 0 && Position3.transform.childCount == 0 && Position4.transform.childCount == 0 && Position5.transform.childCount == 0)
            {
                EnemyEmptyHand = true;
            }
        }
        else if (EnemyEmptyHand && !EnemyRefresh && !PlayersTurn)
        {
            EnemyRefresh = true;
            EnemyDrawCardsToHand();
        }
    }

    public void DrawCardsToHand()
    {
        //These two variables are for checking Deck and Discard pile counts
        var DeckCardsNum = Deck.transform.childCount;
        var DiscardNum = Discard.transform.childCount;

        //These if statements are for filling up the hand with random cards from the deck
        //and/or replacing the deck with cards from the discard pile if the deck is empty
        if (DeckCardsNum >= HandSize)
        {
            var NumChosen = 0;
            while (NumChosen < 5)
            {
                DeckCardsNum = Deck.transform.childCount;
                GameObject[] DeckCards = new GameObject[DeckCardsNum];
                for (int j = 0; j < DeckCardsNum; j++)
                {
                    DeckCards[j] = Deck.transform.GetChild(j).gameObject;
                }
                var card = Random.Range(0, DeckCardsNum);
                if (DeckCards[card] != null)
                {
                    var obj = DeckCards[card];
                    NumChosen++;
                    if (NumChosen == 1)
                    {
                        obj.transform.parent = Position1.transform;
                        obj.transform.localPosition = new Vector3(0, 0, 0);
                        obj.transform.localRotation = new Quaternion(0, 0, 0, transform.rotation.w);
                    }
                    else if (NumChosen == 2)
                    {
                        obj.transform.parent = Position2.transform;
                        obj.transform.localPosition = new Vector3(0, 0, 0);
                        obj.transform.localRotation = new Quaternion(0, 0, 0, transform.rotation.w);
                    }
                    else if(NumChosen == 3)
                    {
                        obj.transform.parent = Position3.transform;
                        obj.transform.localPosition = new Vector3(0, 0, 0);
                        obj.transform.localRotation = new Quaternion(0, 0, 0, transform.rotation.w);
                    }
                    else if (NumChosen == 4)
                    {
                        obj.transform.parent = Position4.transform;
                        obj.transform.localPosition = new Vector3(0, 0, 0);
                        obj.transform.localRotation = new Quaternion(0, 0, 0, transform.rotation.w);
                    }
                    else if (NumChosen == 5)
                    {
                        obj.transform.parent = Position5.transform;
                        obj.transform.localPosition = new Vector3(0, 0, 0);
                        obj.transform.localRotation = new Quaternion(0, 0, 0, transform.rotation.w);
                        Refresh = false;
                        EmptyHand = false;
                    }
                }
            }
        }
        //This is run when the Deck is empty and needs to be refilled by the Discard pile
        else if (DiscardNum > 0)
        {
            for (int i = DiscardNum - 1; i > -1; i--)
            {
                var obj2 = Discard.transform.GetChild(i);
                obj2.transform.parent = Deck.transform;
                obj2.transform.localPosition = Vector3.zero;
            }
            DrawCardsToHand();
        }
    }

    public void EnemyDrawCardsToHand()
    {
        //Ditto but for enemy deck
        var DeckCardsNum = EnemyDeck.transform.childCount;
        var DiscardNum = EnemyDiscard.transform.childCount;
        if (DeckCardsNum >= HandSize)
        {
            var NumChosen = 0;
            while (NumChosen < 5)
            {
                DeckCardsNum = EnemyDeck.transform.childCount;
                GameObject[] DeckCards = new GameObject[DeckCardsNum];
                for (int j = 0; j < DeckCardsNum; j++)
                {
                    DeckCards[j] = EnemyDeck.transform.GetChild(j).gameObject;
                }
                var card = Random.Range(0, DeckCardsNum);
                if (DeckCards[card] != null)
                {
                    var obj = DeckCards[card];
                    NumChosen++;
                    if (NumChosen == 1)
                    {
                        obj.transform.parent = Position1.transform;
                        obj.transform.localPosition = new Vector3(0, 0, 0);
                        obj.transform.localRotation = new Quaternion(0, 0, 0, transform.rotation.w);
                    }
                    else if (NumChosen == 2)
                    {
                        obj.transform.parent = Position2.transform;
                        obj.transform.localPosition = new Vector3(0, 0, 0);
                        obj.transform.localRotation = new Quaternion(0, 0, 0, transform.rotation.w);
                    }
                    else if (NumChosen == 3)
                    {
                        obj.transform.parent = Position3.transform;
                        obj.transform.localPosition = new Vector3(0, 0, 0);
                        obj.transform.localRotation = new Quaternion(0, 0, 0, transform.rotation.w);
                    }
                    else if (NumChosen == 4)
                    {
                        obj.transform.parent = Position4.transform;
                        obj.transform.localPosition = new Vector3(0, 0, 0);
                        obj.transform.localRotation = new Quaternion(0, 0, 0, transform.rotation.w);
                    }
                    else if (NumChosen == 5)
                    {
                        obj.transform.parent = Position5.transform;
                        obj.transform.localPosition = new Vector3(0, 0, 0);
                        obj.transform.localRotation = new Quaternion(0, 0, 0, transform.rotation.w);
                        EnemyRefresh = false;
                        EnemyEmptyHand = false;
                    }
                }
            }
        }
        else if (DiscardNum > 0)
        {
            for (int i = DiscardNum - 1; i > -1; i--)
            {
                var obj2 = EnemyDiscard.transform.GetChild(i);
                obj2.transform.parent = EnemyDeck.transform;
                obj2.transform.localPosition = Vector3.zero;
            }
            EnemyDrawCardsToHand();
        }
    }

    public void UpdateNumbers()
    {
        //This function just updates the UI to reflect changes in Player and Enemy Stat Values
        Canvas.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = PlayerCurrentHealth.ToString();
        Canvas.transform.GetChild(1).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = EnemyCurrentHealth.ToString();
        Canvas.transform.GetChild(2).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = PlayerCurrentAP.ToString();
        Canvas.transform.GetChild(3).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = EnemyCurrentAP.ToString();
    }

    public void EndTurn()
    {
        //This function is used when the player presses the end turn button,
        //and makes sure that everything runs smoothly
        if (PlayersTurn == true)
        {
            PlayersTurn = false;
            PlayerCurrentAP = PlayerAPPerTurn;
            if (Position1.transform.childCount > 0)
            {
                var card = Position1.transform.GetChild(0).gameObject;
                card.transform.parent = Discard.transform;
                card.transform.position = Vector3.zero;
                card.transform.rotation = new Quaternion(0, 0, 0, transform.rotation.w);
            }
            if (Position2.transform.childCount > 0)
            {
                var card = Position2.transform.GetChild(0).gameObject;
                card.transform.parent = Discard.transform;
                card.transform.position = Vector3.zero;
                card.transform.rotation = new Quaternion(0, 0, 0, transform.rotation.w);
            }
            if (Position3.transform.childCount > 0)
            {
                var card = Position3.transform.GetChild(0).gameObject;
                card.transform.parent = Discard.transform;
                card.transform.position = Vector3.zero;
                card.transform.rotation = new Quaternion(0, 0, 0, transform.rotation.w);
            }
            if (Position4.transform.childCount > 0)
            {
                var card = Position4.transform.GetChild(0).gameObject;
                card.transform.parent = Discard.transform;
                card.transform.position = Vector3.zero;
                card.transform.rotation = new Quaternion(0, 0, 0, transform.rotation.w);
            }
            if (Position5.transform.childCount > 0)
            {
                var card = Position5.transform.GetChild(0).gameObject;
                card.transform.parent = Discard.transform;
                card.transform.position = Vector3.zero;
                card.transform.rotation = new Quaternion(0, 0, 0, transform.rotation.w);
            }
        }
        else if (PlayersTurn == false)
        {
            PlayersTurn = true;
            EnemyCurrentAP = EnemyAPPerTurn;
            if (Position1.transform.childCount > 0)
            {
                var card = Position1.transform.GetChild(0).gameObject;
                card.transform.parent = EnemyDiscard.transform;
                card.transform.position = Vector3.zero;
                card.transform.rotation = new Quaternion(0, 0, 0, transform.rotation.w);
            }
            if (Position2.transform.childCount > 0)
            {
                var card = Position2.transform.GetChild(0).gameObject;
                card.transform.parent = EnemyDiscard.transform;
                card.transform.position = Vector3.zero;
                card.transform.rotation = new Quaternion(0, 0, 0, transform.rotation.w);
            }
            if (Position3.transform.childCount > 0)
            {
                var card = Position3.transform.GetChild(0).gameObject;
                card.transform.parent = EnemyDiscard.transform;
                card.transform.position = Vector3.zero;
                card.transform.rotation = new Quaternion(0, 0, 0, transform.rotation.w);
            }
            if (Position4.transform.childCount > 0)
            {
                var card = Position4.transform.GetChild(0).gameObject;
                card.transform.parent = EnemyDiscard.transform;
                card.transform.position = Vector3.zero;
                card.transform.rotation = new Quaternion(0, 0, 0, transform.rotation.w);
            }
            if (Position5.transform.childCount > 0)
            {
                var card = Position5.transform.GetChild(0).gameObject;
                card.transform.parent = EnemyDiscard.transform;
                card.transform.position = Vector3.zero;
                card.transform.rotation = new Quaternion(0, 0, 0, transform.rotation.w);
            }
        }

        UpdateNumbers();
    }

}
