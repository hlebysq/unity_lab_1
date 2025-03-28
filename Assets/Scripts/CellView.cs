using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CellView : MonoBehaviour
{
    public TextMeshProUGUI valueText;
    private Cell cell;
    public Image cellImage;

   

    public void Init(Cell cell)
    {
        this.cell = cell;
        cell.OnValueChanged += UpdateValue;
        cell.OnPositionChanged += UpdatePosition;
        UpdateValue(cell.Value);
        UpdatePosition(cell.Position);
        valueText.transform.SetAsLastSibling();
    }

    private void UpdateValue(int value)
    {
        valueText.text = Mathf.Pow(2, value).ToString();
        cellImage.color = GetColor(value);
    }

    private void UpdatePosition(Vector2Int position)
    {
        transform.localPosition = new Vector3(position.x * 100, position.y * 100, 0);
    }

    private Color GetColor(int value)
    {
        switch (value)
        {
            case 1: return new Color(0.93f, 0.89f, 0.85f); // #EEE4DA
            case 2: return new Color(0.93f, 0.88f, 0.78f); // #EDE0C8
            case 3: return new Color(0.95f, 0.69f, 0.47f); // #F67C5F
            default: return Color.white;
        }
    }
}
