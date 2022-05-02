using UnityEngine;
using UnityEngine.UI;

namespace UserInterfaceComponents
{
    public class FlexGrid : LayoutGroup
    {
        public enum FitType
        {
            Uniform,
            Width,
            Height,
            FixedRows,
            FixedColumns
        }

        [SerializeField] private FitType fitType;
        [SerializeField] private int rows, columns;
        [SerializeField] private Vector2 cellSize, spacing;
        [SerializeField] private bool fitX, fitY;

        public override void CalculateLayoutInputVertical()
        {
            if (fitType == FitType.Width || fitType == FitType.Height || fitType == FitType.Uniform)
            {
                var sqrt = Mathf.Sqrt(transform.childCount);
                rows = columns = Mathf.CeilToInt(sqrt);
                fitX = fitY = true;
            }

            switch (fitType)
            {
                case FitType.FixedColumns:
                case FitType.Width:
                    rows = Mathf.CeilToInt(transform.childCount / (float) columns);
                    break;
                case FitType.FixedRows:
                case FitType.Height:
                    columns = Mathf.CeilToInt(transform.childCount / (float) rows);
                    break;
                case FitType.Uniform:
                default:
                    break;
            }

            var parentWidth = rectTransform.rect.width;
            var parentHeight = rectTransform.rect.height;

            var cellWidth = (parentWidth / (float) columns) - ((spacing.x / (float) columns) * (columns - 1)) - (padding.left / (float) columns) - (padding.right / (float) columns);
            var cellHeight = (parentHeight / (float) rows) - ((spacing.y / (float) rows) * (rows - 1)) - (padding.top / (float) rows) - (padding.bottom / (float) rows);

            cellSize.x = fitX ? cellWidth : cellSize.x;
            cellSize.y = fitY ? cellHeight : cellSize.y;

            var columnCount = 0;
            var rowCount = 0;

            for (var i = 0; i < rectChildren.Count; i++)
            {
                rowCount = i / columns;
                columnCount = i % columns;

                var item = rectChildren[i];

                var xPos = (cellSize.x * columnCount) + (spacing.x * columnCount) + padding.left;
                var yPos = (cellSize.y * rowCount) + (spacing.y * rowCount) + padding.top;

                SetChildAlongAxis(item, 0, xPos, cellSize.x);
                SetChildAlongAxis(item, 1, yPos, cellSize.y);
            }
        }

        public override void SetLayoutHorizontal()
        {
        }

        public override void SetLayoutVertical()
        {
        }
    }
}