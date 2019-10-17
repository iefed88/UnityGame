using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected int rotationSpeed = 1;
    private (float min, float max) destroyPosY;
    private (float min, float max) destroyPosX;
    [SerializeField] protected float fallingSpeed;
    protected void Start()
    {
        fallingSpeed = ActiveLevelData.FallingSpeed;
        destroyPosY = (ScreenBorders.Buttom + ScreenBorders.Buttom / 10, ScreenBorders.Top + ScreenBorders.Top / 10);
        destroyPosX = (ScreenBorders.Left - ScreenBorders.Left / 10, ScreenBorders.Right + ScreenBorders.Right / 10);
    }
    public virtual void Movement()
    {     
        transform.Translate(0, fallingSpeed * Time.deltaTime, 0, Space.World);
    }
    public virtual void Rotation()
    {
        transform.Rotate(0, -rotationSpeed, -rotationSpeed);
    }

    public virtual void Destroy() // TODO: ок, а есть ли еще более оптимальный способ?
    {
        if (transform.localPosition.y < destroyPosY.min || transform.localPosition.y > destroyPosY.max || 
            transform.localPosition.x > destroyPosX.max || transform.localPosition.x < destroyPosX.min)
        {
            ActiveLevelData.EnemiesOnLevel--;
            Destroy(gameObject);
        }
    }
}
