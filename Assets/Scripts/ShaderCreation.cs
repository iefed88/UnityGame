using UnityEngine;

public class ShaderCreation : MonoBehaviour
{
    public GameObject Shader;
    public Material mat;
    public Color color;
    public float alfa = 0.5f;

    public void Shader_Creator1() //Создает куб для затемнения
    {
        Shader = Resources.Load<GameObject>("Forms/ShaderCube") as GameObject;
        Shader = Instantiate(Shader, new Vector3(0, 0, -5), Quaternion.identity);
    }
    public void Shader_Alfa1(float alfa) //Плавно уменьшает прозрачность 
    {
        mat = Shader.GetComponent<MeshRenderer>().material;
        color = mat.color;
        if (color.a == 1.0)
        {
            color.a = 0;
        }
        if (color.a < alfa)
        {
            color.a = color.a + 0.05f;
            mat.color = color;
            Debug.Log(color.a);
        }
        color.a = alfa;
    }
}
