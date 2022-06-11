using System.Text.RegularExpressions;

namespace KlusterG.Essentials
{
    public class Essentials
    {
        public static Tuple<bool, string> IsTextNumeric(string value, bool space = true)
        {
            if (value == null) return new Tuple<bool, string>(false, "Value is null");

            string spaceR = "";

            if (space) spaceR = " ";

            if (Regex.IsMatch(value, $"^[a-zA-Z0-9{spaceR}]+$")) return new Tuple<bool, string>(true, null);

            return new Tuple<bool, string>(false, "Value contains special characters");
        }

        public static Tuple<bool, string> IsEmail(string value)
        {
            if (value == null) return new Tuple<bool, string>(false, "Value is null");

            if (Regex.IsMatch(value, @"^([\w\-]+\.)*[\w\- ]+@([\w\- ]+\.)+([\w\-]{2,3})$")) return new Tuple<bool, string>(true, null);

            return new Tuple<bool, string>(false, "E-mail is not valid");
        }

        public static Tuple<bool, string> IsPassword(string value, bool text = true, bool number = true, int min = 3, int max = 10, string characters = "@!")
        {
            if (value == null) return new Tuple<bool, string>(false, "Value is null");

            string textR = "";
            string numberR = "";

            if (text) textR = "a-zA-Z";

            if (number) numberR = "0-9";

            if (value.Length < min) return new Tuple<bool, string>(false, $"Minimum password length {min}");

            if (value.Length > max) return new Tuple<bool, string>(false, $"Maximum password length {max}");

            if (Regex.IsMatch(value, $"^[{textR}{numberR}{characters}]+$"))
            {
                return new Tuple<bool, string>(true, null);
            }

            return new Tuple<bool, string>(false, "Password is not valid");
        }

        public static Tuple<bool, string> IsText(string value, bool space = true)
        {
            if (value == null) return new Tuple<bool, string>(false, "Value is null");

            string spaceR = "";

            if (space) spaceR = " ";

            if (Regex.IsMatch(value, $"^[a-zA-Z{spaceR}]+$")) return new Tuple<bool, string>(true, null);

            return new Tuple<bool, string>(false, "Text is not valid");
        }

        public static Tuple<bool, string> IsPercentage(string value)
        {
            if (value == null) return new Tuple<bool, string>(false, "Value is null");

            value = value.Replace(" ", "").Replace(",", ".");

            if (Regex.IsMatch(value, @"^[0-9]*?[.]?[0-9]+[%]$")) return new Tuple<bool, string>(true, null);

            return new Tuple<bool, string>(false, "Percent is not valid");
        }

        public static Tuple<bool, string> IsMoney(string value)
        {
            if (value == null) return new Tuple<bool, string>(false, "Value is null");

            value = value.Replace(" ", "").Replace(",", ".").Replace("R", "").Replace("$", "");

            if (Regex.IsMatch(value, @"^[0-9]*?[.]?[0-9]+$")) return new Tuple<bool, string>(true, null);

            return new Tuple<bool, string>(false, "Money is not valid");
        }

        public static Tuple<bool, string> IsNumeric(string value, bool realNumber = false)
        {
            if (value == null) return new Tuple<bool, string>(false, "Value is null");

            string realNumberR = "";

            if (realNumber) realNumberR = "*?[.]?[0-9]";

            if (Regex.IsMatch(value, $"^[0-9]{realNumberR}+$")) return new Tuple<bool, string>(true, null);

            return new Tuple<bool, string>(false, "Numeric is not valid");
        }

        public static bool IsValidCpf(string value)
        {
            List<int> cpf = new List<int>();

            if (value.Length != 11) return false;

            try
            {
                int multi = 10, calc = 0, digitOne, digitTwo;

                for (int i = 0; i < value.Length; i++)
                {
                    cpf.Add(int.Parse(value.Substring(i, 1)));
                }

                for (int i = 0; i < 9; i++)
                {
                    calc += cpf[i] * multi;

                    multi--;
                }

                digitOne = (11 - (calc % 11)) >= 10 ? 0 : (11 - (calc % 11));

                multi = 11;
                calc = 0;

                for (int i = 0; i < 9; i++)
                {
                    calc += cpf[i] * multi;

                    multi--;
                }

                calc += digitOne * multi;

                digitTwo = (11 - (calc % 11)) >= 10 ? 0 : (11 - (calc % 11));

                return digitOne == cpf[9] && digitTwo == cpf[10];
            }
            catch
            {
                return false;
            }
        }
    }
}