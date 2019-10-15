// возвращает в меню выбора уровня из сцены EndScore после поражения.
public class ReturnToMenu : BaseController
{
    void OnMouseDown()
    {
            SceneLoad("SelectLevel");
    }
}