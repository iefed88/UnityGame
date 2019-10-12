using UnityEngine;

public class SplittingEnemy : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Screen borders range from -3.5 to 5.5")]
    private float SplitPosition = 1;
    [SerializeField]
    private int SpawnNumber = 3;
    public GameObject ChildFigure;

    private Transform ThisTransform;
    void Start()
    {
        SplitPosition = Mathf.Clamp(SplitPosition, -3.5f, 5.5f);
        ThisTransform = gameObject.transform;
    }
    void Update()
    {
        if (transform.position.y <= SplitPosition)
        {
            for (int i = 0; i < SpawnNumber; i++)
            {
                Instantiate(ChildFigure, ThisTransform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
