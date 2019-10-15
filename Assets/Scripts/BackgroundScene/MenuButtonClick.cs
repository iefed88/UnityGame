using UnityEngine;

public class MenuButtonClick : BaseController
{
    public GameObject MenuButtonA, MenuButtonB, MenuButtonC, MenuButtonD;
    public void OnMouseDown()
    {
       string buttonName = gameObject.name;
       SceneLoad(buttonName);
        // возврат кнопок меню в исходное положение
       MenuButtonA.GetComponent<ButtonsSlideY>().ButtonPositionReset();
       MenuButtonB.GetComponent<ButtonsSlideY>().ButtonPositionReset();
       MenuButtonC.GetComponent<ButtonsSlideY>().ButtonPositionReset();
       MenuButtonD.GetComponent<ButtonSlideX>().ButtonPositionReset();      
    }
}
