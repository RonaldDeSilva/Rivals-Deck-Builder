using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    private GameObject Deck;
    private GameObject Discard;
    private GameObject Canvas;
    private GameObject EnemyDeck;
    private GameObject EnemyDiscard;

    public int HandSize;
    public bool EmptyHand = true;
    public bool Refresh = false;
    public bool EnemyEmptyHand = true;
    public bool EnemyRefresh = false;
    public bool PlayersTurn = true;

    private GameObject Position1;
    private GameObject Position2;
    private GameObject Position3;
    private GameObject Position4;
    private GameObject Position5;

    public int PlayerAPPerTurn;
    public int PlayerCurrentAP;
    public int EnemyAPPerTurn;
    public int EnemyCurrentAP;
    public int PlayerHealth;
    public int EnemyHealth;
    public int PlayerCurrentHealth;
    public int EnemyCurrentHealth;

    void Start()
    {
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
        var DeckCardsNum = Deck.transform.childCount;
        var DiscardNum = Discard.transform.childCount;
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
        Canvas.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = PlayerCurrentHealth.ToString();
        Canvas.transform.GetChild(1).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = EnemyCurrentHealth.ToString();
        Canvas.transform.GetChild(2).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = PlayerCurrentAP.ToString();
        Canvas.transform.GetChild(3).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = EnemyCurrentAP.ToString();
    }

    public void EndTurn()
    {
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
