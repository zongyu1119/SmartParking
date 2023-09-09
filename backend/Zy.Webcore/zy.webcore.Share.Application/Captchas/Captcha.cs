using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;
using zy.webcore.Share.Constraint.Dtos;

namespace zy.webcore.Share.Application.Captchas
{
    /// <summary>
    /// 验证码
    /// </summary>
    public class Captcha
    {
        private static readonly Color[] colors = new Color[] { Color.Red, Color.Blue, Color.Green, Color.Purple, Color.Peru, Color.LightSeaGreen, Color.Lime, Color.Magenta, Color.Maroon, Color.MediumBlue, Color.MidnightBlue, Color.Navy };

        private static readonly char[] chars = { '0','1','2','3','4','5','6','8','9',
'A','B','C','D','E','F','G','H','J','K', 'L','M','N','P','R','S','T','W','X','Y' };
        //private static readonly int Width = 90;
        //private static readonly int Height = 35;
        private static string getCodes(int num)
        {
            var code = string.Empty;
            var r = new Random();
            for (int i = 0; i < num; i++)
            {
                code += chars[r.Next(chars.Length)].ToString();
            }
            return code;
        }
        private static FontCollection collection = new();
        private static FontFamily family = collection.Add(AppContext.BaseDirectory+"/Fonts/ARIAL.TTF");
        private static Font font = family.CreateFont(20, FontStyle.Bold);
        public static (string code, byte[] bytes) CreateValidateGraphic(int codeLength, int width, int height)
        {
            try
            {
                var code = getCodes(codeLength);
                using Image image = new Image<Rgba32>(width, height);
                //漆底色白色
                image.Mutate(x => x.DrawLines(Pens.DashDot(Color.White, width), new PointF[] { new PointF() { X = 0, Y = 0 }, new PointF() { X = width, Y = height } }));
                PointF startPointF = new PointF(5, 5);
                Random random = new Random(); //随机数产生器
                //绘制大小
                for (int i = 0; i < codeLength; i++)
                {
                    image.Mutate(x => x.DrawText(code[i].ToString(), font, colors[random.Next(colors.Length)], startPointF));
                    startPointF.X += (int)(width - 10) / code.Length;
                    startPointF.Y = random.Next(5, 10);
                }
                IPen pen = Pens.DashDot(Color.Silver, 1);
                //绘制干扰线
                for (var k = 0; k < 40; k++)
                {
                    PointF[] points = new PointF[2];
                    points[0] = new PointF(random.Next(width), random.Next(height));
                    points[1] = new PointF(random.Next(width), random.Next(height));
                    image.Mutate(x => x.DrawLines(pen, points));
                }
                using MemoryStream stream = new MemoryStream();
                image.Save(stream, JpegFormat.Instance);
                //输出图片流  
                return (code, stream.ToArray());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
            }
        }
    }
}
