using System;
using System.Drawing;
using System.Linq;
using System.Xml.Schema;

namespace CLibrary
{
    public struct HSLColor
    {
        public float Hue;
        public float Saturation;
        public float Lightness;
        public float Alpha;

        public HSLColor(Color rgbColor)
        {
            Hue = rgbColor.GetHue();
            Saturation = rgbColor.GetSaturation();
            Lightness = rgbColor.GetBrightness();
            Alpha = rgbColor.A;

            //Console.WriteLine("H: " + Hue + " S: " + Saturation + " L: " + Lightness);
        }

        public Color GetRGB()
        {
            //brightness for min and max saturated colors
            float maxBright = 0, minBright = 0;
            if (Lightness < 0.5f)
                maxBright = Lightness * (1 + Saturation);
            else
                maxBright = (Lightness + Saturation) - (Lightness * Saturation);

            minBright = (Lightness * 2f) - maxBright;

            //angle values shifted by 1/3 to get values in each color range
            float h = Hue / 360f;
            int R = (int)(255 * RGBFromHue(minBright, maxBright, h + 1 / 3f));
            int G = (int)(255 * RGBFromHue(minBright, maxBright, h));
            int B = (int)(255 * RGBFromHue(minBright, maxBright, h - 1 / 3f));

            return Color.FromArgb((int)Alpha, R, G, B);
        }

        private float RGBFromHue(float min, float max, float angle)
        {
            angle = (angle + 1f) % 1f;
			float temp = angle * 6f;
			if (temp < 1f)
				return min + (max - min) * temp;
			if (temp < 3f)
				return max;
			if (temp < 4f)
				return min + (max - min) * (4f - temp);
			return min;

		}
    }

    public static class CSorter
    {
        enum SortStat
        {
            Hue,
            Saturation,
            Lightness
        }

        public static void Sort(float minValue, float maxValue, int stat, int height, HSLColor[] dataLine)
        {
            int startIndex = 0;
            bool inRangeLogic = false;

            //sprawdzenie wejścia/wyjścia z zakresu
            for (int i = 0; i < dataLine.Length; i++)
            {
                bool currInRange = false;
                //Console.WriteLine("DEBUG RGB VALUE:" + dataLine[i].GetRGB());
                switch ((SortStat)stat)
                {
                    case SortStat.Hue:
                        currInRange = CheckIfInRange(minValue, maxValue, dataLine[i].Hue);
                        break;
                    case SortStat.Saturation:
                        currInRange = CheckIfInRange(minValue, maxValue, dataLine[i].Saturation*100.0f);
                        break;
                    case SortStat.Lightness:
                        currInRange = CheckIfInRange(minValue, maxValue, dataLine[i].Lightness*100.0f);
                        break;
                }

                if (!inRangeLogic && currInRange)
                {
                    startIndex = i;
                    inRangeLogic = true;
                }
                else if (inRangeLogic && (!currInRange || i == dataLine.Length - 1))
                {
                    int length = i - startIndex;
                    HSLColor[] range = dataLine.Skip(startIndex).Take(length).ToArray();

                    switch ((SortStat)stat)
                    {
                        case SortStat.Hue:
                            InsertionSort(range, (a, b) => a.Hue.CompareTo(b.Hue));
                            break;
                        case SortStat.Saturation:
                            InsertionSort(range, (a, b) => a.Saturation.CompareTo(b.Saturation));
                            break;
                        case SortStat.Lightness:
                            InsertionSort(range, (a, b) => a.Lightness.CompareTo(b.Lightness));
                            break;
                    }
                    Array.Copy(range, 0, dataLine, startIndex, length);
                    inRangeLogic = false;
                }

            }
        }

        private static bool CheckIfInRange(float min, float max, float value)
        {
            if (value >= min && value <= max)
                return true;
            else return false;
        }

        private static HSLColor[] InsertionSort(HSLColor[] dataLine, Comparison<HSLColor> comparison)
        {
            for(int i = 0; i < dataLine.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (comparison(dataLine[j], dataLine[j - 1]) < 0)
                    {
                        HSLColor temp = dataLine[j - 1];
                        dataLine[j - 1] = dataLine[j];
                        dataLine[j] = temp;
                    }
                }
                //dataLine[i].Lightness = 1.0f;
            }
            //dataLine[dataLine.Length - 1].Lightness = 1.0f;

			return dataLine;
        } 
    }
}
