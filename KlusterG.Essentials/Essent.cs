using KlusterG.Essentials.Enums;
using System.Text.RegularExpressions;

namespace KlusterG.Essentials
{
    public class Essent
    {
        public Reasons Reason { get; set; }

        public bool IsTextNumeric(string value, bool space = true)
        {
            if (value == null)
            {
                Reason = Reasons.IsNull;
                return false;
            }

            string spaceR = "";

            if (space) spaceR = " ";

            if (Regex.IsMatch(value, $"^[a-zA-Z0-9{spaceR}]+$")) return true;

            Reason = Reasons.Invalid;
            return false;
        }

        public bool IsEmail(string value)
        {
            if (value == null)
            {
                Reason = Reasons.IsNull;
                return false;
            }

            if (Regex.IsMatch(value, @"^([\w\-]+\.)*[\w\- ]+@([\w\- ]+\.)+([\w\-]{2,3})$")) return true;

            Reason = Reasons.Invalid;
            return false;
        }

        public bool IsPassword(string value, bool text = true, bool number = true, int min = 3, int max = 10, string characters = "@!")
        {
            if (value == null)
            {
                Reason = Reasons.IsNull;
                return false;
            }

            string textR = "";
            string numberR = "";

            if (text) textR = "a-zA-Z";

            if (number) numberR = "0-9";

            if (value.Length < min)
            {
                Reason = Reasons.BelowTheMinimum;
                return false;
            }

            if (value.Length > max)
            {
                Reason = Reasons.AboveTheMaximum;
                return false;
            }

            if (Regex.IsMatch(value, $"^[{textR}{numberR}{characters}]+$"))
            {
                return true;
            }

            Reason = Reasons.Invalid;
            return false;
        }

        public bool IsText(string value, bool space = true)
        {
            if (value == null)
            {
                Reason = Reasons.IsNull;
                return false;
            }

            string spaceR = "";

            if (space) spaceR = " ";

            if (Regex.IsMatch(value, $"^[a-zA-Z{spaceR}]+$")) return true;

            Reason = Reasons.Invalid;
            return false;
        }

        public bool IsCustomText(string value, string characters, bool space = true)
        {
            if (value == null)
            {
                Reason = Reasons.IsNull;
                return false;
            }

            string spaceR = "";

            if (space) spaceR = " ";

            if (Regex.IsMatch(value, $"^[a-zA-Z{characters}{spaceR}]+$")) return true;

            Reason = Reasons.Invalid;
            return false;
        }

        public bool IsPercentage(string value)
        {
            if (value == null)
            {
                Reason = Reasons.IsNull;
                return false;
            }

            value = value.Replace(" ", "").Replace(",", ".");

            if (Regex.IsMatch(value, @"^[0-9]*?[.]?[0-9]+[%]$")) return true;

            Reason = Reasons.Invalid;
            return false;
        }

        public bool IsMoney(string value)
        {
            if (value == null)
            {
                Reason = Reasons.IsNull;
                return false;
            }

            value = value.Replace(" ", "").Replace(",", ".").Replace("R", "").Replace("$", "");

            if (Regex.IsMatch(value, @"^[0-9]*?[.]?[0-9]+$")) return true;

            Reason = Reasons.Invalid;
            return false;
        }

        public bool IsNumeric(string value, bool realNumber = false)
        {
            if (value == null)
            {
                Reason = Reasons.IsNull;
                return false;
            }

            string realNumberR = "";

            if (realNumber) realNumberR = "*?[.]?[0-9]";

            if (Regex.IsMatch(value, $"^[0-9]{realNumberR}+$")) return true;

            Reason = Reasons.Invalid;
            return false;
        }

        public bool IsValidCpf(string value)
        {
            List<int> cpf = new List<int>();

            value = value.Replace(".", "").Replace("-", "");

            if (value.Length != 11)
            {
                Reason = Reasons.InvalidNumberOfDigits;
                return false;
            }

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

                if (digitOne == cpf[9] && digitTwo == cpf[10])
                {
                    return true;
                }

                Reason = Reasons.Invalid;
                return false;
            }
            catch
            {
                Reason = Reasons.Invalid;
                return false;
            }
        }

        public bool IsValidRg(string value)
        {
            List<int> rg = new List<int>();

            value = value.Replace(".", "").Replace("-", "");

            if (value.Length != 9)
            {
                Reason = Reasons.InvalidNumberOfDigits;
                return false;
            }

            try
            {
                for (int i = 0; i < value.Length - 1; i++)
                {
                    rg.Add(int.Parse(value.Substring(i, 1)));
                }

                int calcNumber = 2;

                for (int i = 0; i < 8; i++)
                {
                    rg[i] = rg[i] * calcNumber;

                    calcNumber++;
                }

                int result = rg[0] + rg[1] + rg[2] + rg[3] + rg[4] + rg[5] + rg[6] + rg[7];
                result = 11 - (result % 11);

                if (result == int.Parse(value.Last().ToString()))
                {
                    return true;
                }

                Reason = Reasons.Invalid;
                return false;
            }
            catch
            {
                Reason = Reasons.Invalid;
                return false;
            }
        }

        public bool IsValidCnpj(string value)
        {
            List<int> cnpj = new List<int>();

            value = value.Replace(".", "").Replace("-", "").Replace("/", "");

            string dv = "";

            if (value.Length != 14)
            {
                Reason = Reasons.InvalidNumberOfDigits;
                return false;
            }

            try
            {
                for (int i = 0; i < value.Length - 2; i++)
                {
                    cnpj.Add(int.Parse(value.Substring(i, 1)));
                }

                int calcNumber = 6;

                for (int i = 0; i < 12; i++)
                {
                    cnpj[i] = cnpj[i] * calcNumber;

                    if (calcNumber == 9)
                        calcNumber = 2;
                    else
                        calcNumber++;
                }

                int result = cnpj[0] + cnpj[1] + cnpj[2] + cnpj[3] + cnpj[4] + cnpj[5] + cnpj[6] + cnpj[7] + cnpj[8] + cnpj[9] + cnpj[10] + cnpj[11];
                result = result % 11;

                dv = result >= 10 ? "0" : result.ToString();

                cnpj = new List<int>();

                for (int i = 0; i < value.Length - 2; i++)
                {
                    cnpj.Add(int.Parse(value.Substring(i, 1)));
                }

                cnpj.Add(int.Parse(dv));

                calcNumber = 5;

                for (int i = 0; i < 13; i++)
                {
                    cnpj[i] = cnpj[i] * calcNumber;

                    if (calcNumber == 9)
                        calcNumber = 2;
                    else
                        calcNumber++;
                }

                result = cnpj[0] + cnpj[1] + cnpj[2] + cnpj[3] + cnpj[4] + cnpj[5] + cnpj[6] + cnpj[7] + cnpj[8] + cnpj[9] + cnpj[10] + cnpj[11] + cnpj[12];
                result = result % 11;

                dv += result >= 10 ? "0" : result.ToString();

                if (dv == value.Substring(12, 2))
                {
                    return true;
                }

                Reason = Reasons.Invalid;
                return false;
            }
            catch
            {
                Reason = Reasons.Invalid;
                return false;
            }
        }
    }
}