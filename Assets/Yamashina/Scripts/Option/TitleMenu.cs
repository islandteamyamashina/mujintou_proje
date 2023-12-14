using UnityEngine;
public abstract class TitleMenu : MonoBehaviour
{
    public Sprite OffSprite;
    public Sprite OnSprite;

    // 画像描画用のコンポーネント
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // カーソルが合っているとき
    public void On()
    {
        // 画像を切り替える
        spriteRenderer.sprite = OnSprite;
    }
    // カーソルが合っていないとき
    public void Off()
    {
        // 画像を切り替える
        spriteRenderer.sprite = OffSprite;
    }
    public abstract IEnumerator Select();
}

// 決定されたときの動作
