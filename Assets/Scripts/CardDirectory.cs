using UnityEngine;

public class CardDirectory : MonoBehaviour
{
    private GameController GameController;

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
}
