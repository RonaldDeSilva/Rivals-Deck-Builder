using UnityEngine;

public class EnemyCardBehavior : MonoBehaviour
{
    private bool FollowMouse = false;
    private GameObject EnemyDiscard;
    private Rigidbody rb;
    public bool OverHand = true;
    private bool RunOnce = false;
    private float YVal = 50.0f;
    public string Effect;
    private CardDirectory CardEffects;
    public int APCost;
    private GameController GameController;

    void Start()
    {
        EnemyDiscard = GameObject.Find("EnemyDiscard");
        rb = GetComponent<Rigidbody>();
        CardEffects = GameObject.FindGameObjectWithTag("GameController").GetComponent<CardDirectory>();
        GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        if (FollowMouse)
        {
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z - 5));
            rb.position = mouseWorldPos;
            if (!RunOnce)
            {
                YVal = transform.position.y;
                RunOnce = true;
            }
        }
        else if (transform.parent.name != "EnemyDeck")
        {
            transform.localPosition = new Vector3(0, 0, 0);
            transform.localRotation = new Quaternion(0, 0, 0, transform.rotation.w);
        }
    }

    private void OnMouseDown()
    {
        if (transform.parent.name == "Position 1" || transform.parent.name == "Position 2" || transform.parent.name == "Position 3" || transform.parent.name == "Position 4" || transform.parent.name == "Position 5")
        {
            if (FollowMouse)
            {
                FollowMouse = false;
                RunOnce = false;
                if (transform.position.y >= YVal + 2f && APCost <= GameController.EnemyCurrentAP)
                {
                    GameController.EnemyCurrentAP -= APCost;
                    CardEffects.UseCard(Effect, false);
                    transform.parent = EnemyDiscard.transform;
                }
            }
            else
            {
                FollowMouse = true;
            }
        }
    }
}
