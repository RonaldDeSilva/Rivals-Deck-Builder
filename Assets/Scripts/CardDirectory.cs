using UnityEngine;

public class CardDirectory : MonoBehaviour
{
    //---------The Card Directory keeps track of all the card effects-------------//


    private GameController GameController;
    public GameObject[] Creatures;
    public GameObject TempCard;
    public string TempMonster;

    private void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void UseCard(string EffectName, bool isPlayer)
    {
        if (isPlayer)
        {
            if (EffectName == "Attack")
            {
                GameController.EnemyCurrentHealth -= 5;
            }
            else if (EffectName == "Heal")
            {
                GameController.PlayerCurrentHealth += 5;
            }
        }
        else if (!isPlayer)
        {
            if (EffectName == "Attack")
            {
                GameController.PlayerCurrentHealth -= 5;
            }
            else if (EffectName == "Heal")
            {
                GameController.EnemyCurrentHealth += 5;
            }
        }

        GameController.UpdateNumbers();
    }

    public void SummonCreature(GameObject Card, string Monster)
    {
        TempCard = Card;
        TempMonster = Monster;
    }

    public void SlotCommunication(string SlotNumber)
    {
        if (TempMonster == "Summon")
        {
            if (SlotNumber == "PlayerTopSlot1")
            {
                var Mon = Instantiate(Creatures[0], GameController.PlayerTopSlot1.transform);
                Mon.transform.localPosition = Vector3.zero;
                GameController.PlayerOpenSlots -= 1;
            }
            else if (SlotNumber == "PlayerTopSlot2")
            {
                var Mon = Instantiate(Creatures[0], GameController.PlayerTopSlot2.transform);
                Mon.transform.localPosition = Vector3.zero;
                GameController.PlayerOpenSlots -= 1;
            }
            else if (SlotNumber == "PlayerBottomSlot1")
            {
                var Mon = Instantiate(Creatures[0], GameController.PlayerBottomSlot1.transform);
                Mon.transform.localPosition = Vector3.zero;
                GameController.PlayerOpenSlots -= 1;
            }
            else if (SlotNumber == "PlayerBottomSlot2")
            {
                var Mon = Instantiate(Creatures[0], GameController.PlayerBottomSlot2.transform);
                Mon.transform.localPosition = Vector3.zero;
                GameController.PlayerOpenSlots -= 1;
            }
            else if (SlotNumber == "EnemyTopSlot1")
            {
                var Mon = Instantiate(Creatures[0], GameController.EnemyTopSlot1.transform);
                Mon.transform.localPosition = Vector3.zero;
                GameController.EnemyOpenSlots -= 1;
            }
            else if (SlotNumber == "EnemyTopSlot2")
            {
                var Mon = Instantiate(Creatures[0], GameController.EnemyTopSlot2.transform);
                Mon.transform.localPosition = Vector3.zero;
                GameController.EnemyOpenSlots -= 1;
            }
            else if (SlotNumber == "EnemyBottomSlot1")
            {
                var Mon = Instantiate(Creatures[0], GameController.EnemyBottomSlot1.transform);
                Mon.transform.localPosition = Vector3.zero;
                GameController.EnemyOpenSlots -= 1;
            }
            else if (SlotNumber == "EnemyBottomSlot2")
            {
                var Mon = Instantiate(Creatures[0], GameController.EnemyBottomSlot2.transform);
                Mon.transform.localPosition = Vector3.zero;
                GameController.EnemyOpenSlots -= 1;
            }
        }
        TempCard.transform.parent = GameController.Discard.transform;
        TempCard.transform.position = Vector3.zero;
        TempCard.transform.rotation = new Quaternion(0, 0, 0, TempCard.transform.rotation.w);
        TempCard = null;
        TempMonster = null;
    }
}
