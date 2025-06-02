using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCiphers01.Utilities;

namespace WPFCiphers01.Models
{
    public class AtbashConvert : ICipherConvert
    {
        public string Encipher(string answer)
        {
            return GetAssociatedLetter(answer);
        }
        private string GetAssociatedLetter(string answer)
        {
            string currentHint = String.Empty;
            foreach (char c in answer)
            {
                currentHint += GetRelatedCharacter(c);
            }
            return currentHint;
        }

        private char GetRelatedCharacter(char c)
        {
            if (Algorithms.AtbashDictionary != null)
            {
                if (Algorithms.AtbashDictionary.TryGetValue(c, out char value))
                {
                    return value;
                }
                else
                {
                    return c;
                }
            }
            else
            {
                return c;
            }
        }
    }

    public class MorseConvert : ICipherConvert
    {
        public string Encipher(string answer)
        {
            return GetAssociatedString(answer);
        }

        private string GetAssociatedString(string answer)
        {
            string Hint = String.Empty;
            foreach (char c in answer.ToUpper())
            {
                Hint += GetRelatedString(c) + " ";
            }
            return Hint;
        }

        private string GetRelatedString(char c)
        {
            if ((Algorithms.MorseDictionary != null))
            {
                if (Algorithms.MorseDictionary.TryGetValue(c, out string? value))
                {
                    return value;
                }
                else
                {
                    return c.ToString();
                }
            }
            else { return c.ToString(); }
        }

    }
    
    public class PolybiusConvert : ICipherConvert
    {       
        public string Encipher(string answer)
        {
            return DivulgeAnswer(answer);
        }

        private string DivulgeAnswer(string answer)
        {
            string Hint = string.Empty;

            if ((Algorithms.PolybiusDT != null))
            {
                foreach (char character in answer)
                {
                    if ((character >= 'A' && character < 'Y') || (character >= 'a' && character < 'y'))
                    {
                        bool characterFound = false;
                        try
                        {
                            foreach (System.Data.DataRow dr in Algorithms.PolybiusDT.Rows)
                            {
                                for (int y = 1; y < Algorithms.PolybiusDT.Columns.Count; y++)
                                {
                                    Char currentDTChar = Convert.ToChar(dr[y]);
                                    if (currentDTChar == Char.ToUpper(character))
                                    {
                                        Hint += Algorithms.PolybiusDT.Columns[y].ColumnName + ":" + (Algorithms.PolybiusDT.Rows.IndexOf(dr) + 1).ToString() + " ";
                                        characterFound = true;
                                        break;
                                    }
                                }
                                if (characterFound)
                                {
                                    break;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                    else
                    {
                        if (character == 'z')
                        {
                            Hint += "Z ";
                        }
                        else
                        {
                            Hint += character.ToString() + " ";
                        }
                    }
                }
            }

            return Hint;
        }
    }
}
