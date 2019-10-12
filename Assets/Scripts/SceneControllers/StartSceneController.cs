using UnityEngine;

public class StartSceneController : BaseController
{
    private const byte buildIndex = 1;

    private Player_Assembler _Player_Assembler;
    void Start()
    {
        thisSetActive(buildIndex); //установка данной сцены активной методом из наследуемого класса

        _Player_Assembler = gameObject.AddComponent<Player_Assembler>();
        _Player_Assembler.Player_Creator(new Vector3(0, 1, 0), SceneController.lastForm);
    }
}
