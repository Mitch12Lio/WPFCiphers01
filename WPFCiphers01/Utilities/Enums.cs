using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCiphers01.Utilities
{
    internal enum CipherTypes
    {
        Atbash, Ceasar, Morse, Pic, PigPen, Playfair, Polybius
    }

    internal enum EggColours
    {
        Purple, Blue, Green, Red, Yellow, Orange
    }

    internal enum VisibilityTypes
    {
        Collapsed, Visible, Hidden
    }

    internal struct LocationTypes
    {
        public const string MainLevel = "Mail Level";
        public const string Upstairs = "Upstairs";
        public const string Basement = "Basement";
        public const string Garage = "Garage";
        public const string Attic = "Attic";
        public const string Frontyard = "Front Yard";
        public const string Backyard = "Back Yard";
        public const string Other = "Other";
    }

    internal struct StatusMessages
    {
        public const string Ready = "Ready!";
        public const string AnAnswerIsRequired = "An answer is required.";
        public const string PrintedAt = "Printed at ";
        public const string NoCiphersToPrint = "No ciphers to print.";
    }
}
