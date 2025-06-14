﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCiphers01.MVVM;

namespace WPFCiphers01.Models
{
    public abstract class Cipher : ObservableObject
    {
        public ICipherConvert? cipherConvert;     

        public int Id { get; set; }

        public Guid GuidId { get; set; }

        //I put these into getters and setters to update the listbox:

        //The thing is, ObservableCollection raises the CollectionChanged event when an item is added/deleted/moved.But it doesn't raise the PropertyChanged event when the property of one of its items is updated.
        //You need to implement the INotifyPropertyChanged interface and raise the PropertyChanged event on the property setters of your MvItems class.

        //perhaps creating DTO's will solve the problem of having MVVM included in models?

        private string hint = string.Empty;
        public string Hint
        {
            get
            {
                return hint;
            }
            set
            {
                hint = value;
                OnPropertyChanged(nameof(Hint));
            }
        }

        private string answer = string.Empty;

        //[Required(ErrorMessage ="Answer is Required")]
        public string Answer
        {
            get
            {
                return answer;
            }
            set
            {
                answer = value;
                //Validate(nameof(Answer), value);
                OnPropertyChanged(nameof(Answer));
            }
        }

        private string cipherType = string.Empty;
        public string CipherType
        {
            get
            {
                return cipherType;
            }
            set
            {
                cipherType = value;
                OnPropertyChanged(nameof(CipherType));
            }
        }

        private CipherLocation? cipherLocation = null;
        public CipherLocation? CipherLocation
        {
            get
            {
                return cipherLocation;
            }
            set
            {
                cipherLocation = value;
                OnPropertyChanged(nameof(CipherLocation));
            }
        }

        private EggColour? eggColour = null;
        public EggColour? EggColour
        {
            get
            {
                return eggColour;
            }
            set
            {
                eggColour = value;
                OnPropertyChanged(nameof(EggColour));

            }
        }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public int? ParticipantId { get; set; }

        public int? SeasonId { get; set; }

        public int? CipherLocationId { get; set; }

        public string performConvert(string answer)
        {
            if (cipherConvert != null)
            {
                return cipherConvert.Encipher(answer);
            }
            else { return string.Empty; }
        }

        public abstract string ExecuteAnswer();
    }

    public class CipherLocation()
    {
        public int Id;
        public string? Location { get; set; }
    }

    public class EggColour()
    {
        public int Id;
        public string? Colour { get; set; }
    }

    public class AtbashCipher : Cipher
    {
        public AtbashCipher()
        {
            cipherConvert = new AtbashConvert();
        }
        public override string ExecuteAnswer()
        {
            return string.Empty;
        }
    }  

    public class MorseCipher : Cipher
    {
        public MorseCipher()
        {
            cipherConvert = new MorseConvert();
        }
        public override string ExecuteAnswer()
        {
            return "Encrypting Morse";
        }
    }
    public class PolybiusCipher : Cipher
    {
        public PolybiusCipher()
        {
            cipherConvert = new PolybiusConvert();
        }
        public override string ExecuteAnswer()
        {
            return "Encrypting Polybius";
        }
    }

    public class CeasarCipher : Cipher
    {
        public override string ExecuteAnswer()
        {
            return string.Empty;
        }
    }

}
