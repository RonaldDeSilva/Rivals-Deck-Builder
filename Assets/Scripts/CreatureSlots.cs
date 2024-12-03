using UnityEngine;

public class CreatureSlots : MonoBehaviour
{
    private CardDirectory Directory;
    public string SlotName;

    private void Start()
    {
        Directory = GameObject.Find("GameController").GetComponent<CardDirectory>();
    }

    private void OnMouseDown()
    {
        if (Directory.TempCard != null)
        {
            Directory.SlotCommunication(SlotName);
        }
    }
}
