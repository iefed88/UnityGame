using UnityEngine;
using UnityEngine.EventSystems;

public class AndroidControlls : MonoBehaviour, IDragHandler

{
    public LevelSceneController _LevelSceneController;
    float PlayerRadius;
    float minX, maxX, minY;
    public static bool GameIsPaused = false;
    public int Sens = 100; //настройка чувствительности
    private GameObject Player;
    Transform LeftFoot;
    Transform RightFoot;
    float ymin = 2;
    float ymax = (float)0.8;

    void Start()
    {
        minX = ScreenBorders.Left;
        maxX = ScreenBorders.Right;
        minY = ScreenBorders.Buttom;
        Player = _LevelSceneController.Player;
        PlayerRadius = Player.transform.localScale.x / 2;
        LeftFoot = Player.transform.GetChild(2);
        RightFoot = Player.transform.GetChild(3);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!GameIsPaused) //TODO: почему тут своя переменная? Зачем так, может переделать?
        {

            Vector3 playerPosition = Player.transform.position;
            float XSens = eventData.delta.x / Sens;
            float YSens = eventData.delta.y / Sens;
            playerPosition.x = Mathf.Clamp(Player.transform.position.x + XSens, minX + PlayerRadius, maxX - PlayerRadius);
            playerPosition.y = Mathf.Clamp(Player.transform.position.y + YSens, minY + PlayerRadius, 0);
            Player.transform.position = playerPosition;
            PlayerRotation(XSens);
            ChangeFootPosition(YSens);
        }
    }
    private void ChangeFootPosition(float YSens) //TODO: перенести в отдельный класс, класс уже создан
    {
        Vector3 LeftFootPosition = LeftFoot.position;
        LeftFootPosition.x = Player.transform.position.x - (float)0.25;
        Vector3 RightFootPosition = RightFoot.position;
        RightFootPosition.x = Player.transform.position.x + (float)0.25;

        if (YSens != 0)
        {
            LeftFootPosition.y = Mathf.Clamp(LeftFoot.position.y + 2 * -YSens, Player.transform.position.y - ymin, Player.transform.position.y - ymax);
            LeftFoot.position = LeftFootPosition;

            RightFootPosition.y = Mathf.Clamp(RightFoot.position.y + 2 * -YSens, Player.transform.position.y - ymin, Player.transform.position.y - ymax);
            RightFoot.position = RightFootPosition;
        }
        if (YSens > 0.1 | YSens < 0.1)
        {
            LeftFootPosition.y = Mathf.Clamp(LeftFoot.position.y + (float)0.2, Player.transform.position.y - ymin, Player.transform.position.y - ymax);
            LeftFoot.position = LeftFootPosition;

            RightFootPosition.y = Mathf.Clamp(RightFoot.position.y + (float)0.2, Player.transform.position.y - ymin, Player.transform.position.y - ymax);
            RightFoot.position = RightFootPosition;
        }
    }
    private void PlayerRotation(float XSens)
    {
        if (Player.transform.position.x < 0)
        {
            Player.transform.Rotate(Vector3.back * 10 * XSens);

        }
        else if (Player.transform.position.x > 0)
        {
            Player.transform.Rotate(Vector3.forward * 10 * -XSens);
        }
    }
    public void OnEndDrag(PointerEventData eventData) { }
    public void OnBeginDrag(PointerEventData eventData) { }
}
