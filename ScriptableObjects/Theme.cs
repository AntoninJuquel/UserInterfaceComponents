using TMPro;
using UnityEngine;

namespace UserInterfaceComponents.ScriptableObjects
{
    [System.Serializable]
    public class CommonColor
    {
        public Color black = Color.black;
        public Color white = Color.white;
    }

    [System.Serializable]
    public class ColorObject
    {
        public Color main, light, dark, contrastText;

        public ColorObject(Color main, Color light, Color dark, Color contrastText)
        {
            this.main = main;
            this.light = light;
            this.dark = dark;
            this.contrastText = contrastText;
        }
    }

    [System.Serializable]
    public class ColorAction
    {
        public Color active = new Color(0, 0, 0, .54f);
        public Color hover = new Color(0, 0, 0, .04f);
        public Color selected = new Color(0, 0, 0, .08f);
        public Color disabled = new Color(0, 0, 0, .26f);
        public Color disabledBackground = new Color(0, 0, 0, .12f);
        public Color focus = new Color(0, 0, 0, .12f);
    }

    [System.Serializable]
    public class ColorBackground
    {
        public Color paper = Color.white;
        public Color defaultBackground = Color.white;
    }

    [System.Serializable]
    public class ColorText
    {
        public Color primary = new Color(0, 0, 0, .87f);
        public Color secondary = new Color(0, 0, 0, .6f);
        public Color disabledv = new Color(0, 0, 0, .38f);
    }

    [System.Serializable]
    public class Palette
    {
        public CommonColor common;

        public ColorObject primary = new ColorObject(new Color(25, 118, 210), new Color(66, 165, 245), new Color(21, 101, 192), Color.white);
        public ColorObject secondary = new ColorObject(new Color(156, 39, 176), new Color(186, 104, 200), new Color(123, 31, 162), Color.white);
        public ColorObject error = new ColorObject(new Color(211, 47, 47), new Color(239, 83, 80), new Color(198, 40, 40), Color.white);
        public ColorObject warning = new ColorObject(new Color(237, 108, 2), new Color(255, 152, 0), new Color(230, 81, 0), Color.white);
        public ColorObject info = new ColorObject(new Color(2, 136, 209), new Color(3, 169, 244), new Color(1, 87, 155), Color.white);
        public ColorObject success = new ColorObject(new Color(46, 127, 50), new Color(76, 175, 80), new Color(27, 94, 32), Color.white);

        public ColorAction action;
        public ColorBackground background;
        public ColorText text;
    }

    [System.Serializable]
    public class TextObject
    {
        public TMP_FontAsset fontFamily;
        public FontWeight fontWeight;
        public float fontSize;
        public float lineSpacing;
        public float characterSpacing;
        public FontStyles fontStyle = FontStyles.Normal;

        public TextObject(FontWeight fontWeight, float fontSize, float lineSpacing, float characterSpacing, FontStyles fontStyle = FontStyles.Normal)
        {
            this.fontWeight = fontWeight;
            this.fontSize = fontSize;
            this.lineSpacing = lineSpacing;
            this.characterSpacing = characterSpacing;
            this.fontStyle = fontStyle;
        }
    }

    [System.Serializable]
    public class Typography
    {
        public TMP_FontAsset fontFamily;
        public int htmlFontSize = 16;
        public int fontSize = 14;
        public FontWeight fontWeightLight = FontWeight.Light;
        public FontWeight fontWeightRegular = FontWeight.Regular;
        public FontWeight fontWeightMedium = FontWeight.Medium;
        public FontWeight fontWeightBold = FontWeight.Bold;

        public TextObject h1 = new TextObject(FontWeight.Light, 96, 1.167f, -1.5f);
        public TextObject h2 = new TextObject(FontWeight.Light, 60, 1.2f, -0.5f);
        public TextObject h3 = new TextObject(FontWeight.Regular, 48, 1.167f, 0);
        public TextObject h4 = new TextObject(FontWeight.Regular, 34, 1.235f, 0.25f);
        public TextObject h5 = new TextObject(FontWeight.Regular, 24, 1.334f, 0);
        public TextObject h6 = new TextObject(FontWeight.Medium, 20, 1.6f, 0.15f);
        public TextObject subtitle1 = new TextObject(FontWeight.Regular, 16, 1.75f, 0.15f);
        public TextObject subtitle2 = new TextObject(FontWeight.Medium, 14, 1.57f, 0.1f);
        public TextObject body1 = new TextObject(FontWeight.Regular, 16, 1.5f, 0.15f);
        public TextObject body2 = new TextObject(FontWeight.Regular, 14, 1.43f, 0.15f);
        public TextObject button = new TextObject(FontWeight.Medium, 14, 1.75f, 0.4f, FontStyles.UpperCase);
        public TextObject caption = new TextObject(FontWeight.Regular, 12, 1.66f, 0.4f);
        public TextObject overline = new TextObject(FontWeight.Regular, 12, 2.66f, 1, FontStyles.UpperCase);
    }

    [CreateAssetMenu(menuName = "User Interface Components/Theme")]
    public class Theme : ScriptableObject
    {
        public Palette palette;
        public Typography typography;
    }
}