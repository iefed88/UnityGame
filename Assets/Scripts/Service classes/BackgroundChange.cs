using UnityEngine;

public class BackgroundChange : MonoBehaviour
{
    public Material SceneSkybox;
    void Start()
    {
        Camera camera = WorldCamera._camera;
        camera.GetComponent<Skybox>().material = SceneSkybox as Material;
    }
}
