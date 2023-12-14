using UnityEngine;
public abstract class TitleMenu : MonoBehaviour
{
    public Sprite OffSprite;
    public Sprite OnSprite;

    // �摜�`��p�̃R���|�[�l���g
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // �J�[�\���������Ă���Ƃ�
    public void On()
    {
        // �摜��؂�ւ���
        spriteRenderer.sprite = OnSprite;
    }
    // �J�[�\���������Ă��Ȃ��Ƃ�
    public void Off()
    {
        // �摜��؂�ւ���
        spriteRenderer.sprite = OffSprite;
    }
    public abstract IEnumerator Select();
}

// ���肳�ꂽ�Ƃ��̓���
