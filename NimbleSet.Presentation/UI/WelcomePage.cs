
namespace NimbleSet.Presentation.UI;

public class WelcomePage
{
    public class CaptchaResult
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int CorrectSum { get; set; }
    }
    public CaptchaResult CaptchaGenerator()
    {
        Random random = new Random();
        int number1 = random.Next(1, 101);
        int number2 = random.Next(1, 101);

        int correctSum = number1 + number2;

        CaptchaResult result = new CaptchaResult
        {
            Number1 = number1,
            Number2 = number2,
            CorrectSum = correctSum
        };

        return result;
    }

    public bool Validator(int a, int b, int num)
    {
        int result = a + b;
        return result == num;

    }

    public bool Signin()
    {
        try
        {
            CaptchaResult captchaValidCheck = CaptchaGenerator();
            Console.Write($"{captchaValidCheck.Number1} + {captchaValidCheck.Number2} = ?\nInput correct result: ");
            int number = int.Parse(Console.ReadLine());

            if (Validator(captchaValidCheck.Number1, captchaValidCheck.Number2, number))
                return true;
            return false;

        }
        catch (Exception e)
        {
            Console.WriteLine($"Error {e}");
            return false;
        }
    }



}
