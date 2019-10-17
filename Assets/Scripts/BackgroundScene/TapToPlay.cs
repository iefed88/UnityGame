// Обрабатывает переход на предыдущий уровень, в который играл игрок по тапу из StartScene
public class TapToPlay : BaseController
{
    void OnMouseDown()
    {
        if (!PauseButton.PauseClick) // блокировка при нажатой кнопке паузы (при открытом меню).
        {
            SceneLoad(SceneController.LastLevel);
        }
    }
}