﻿public class MenuButtonClick : BaseController
{
    // обрабатывает клик по кнопке меню для перехода на новую сцену
    public ButtonsSlideY MenuButtonA, MenuButtonB, MenuButtonC; 
    public ButtonSlideX MenuButtonD;
    public void OnMouseDown()
    {
        // возврат кнопок меню в исходное положение
        MenuButtonA.ButtonPositionReset();
        MenuButtonB.ButtonPositionReset();
        MenuButtonC.ButtonPositionReset();
        MenuButtonD.ButtonPositionReset();
        // загрузка уровня через имя кнопки
        SceneLoad(gameObject.name);
    }
}
