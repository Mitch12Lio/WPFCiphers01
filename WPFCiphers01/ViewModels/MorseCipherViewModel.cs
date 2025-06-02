using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCiphers01.Models;
using WPFCiphers01.Utilities;

namespace WPFCiphers01.ViewModels
{
    public class MorseCipherViewModel : CipherViewModel
    {
        #region Properties/Fields

        //for display
        Dictionary<char, String>? morseDictionary = Algorithms.MorseDictionary;
        public Dictionary<char, String>? MorseDictionary
        {
            get
            {
                return morseDictionary;
            }
            set
            {
                morseDictionary = value;
                OnPropertyChanged(nameof(MorseDictionary));
            }
        }


        private Cipher currentCipher = new MorseCipher();
        public override Cipher CurrentCipher
        {
            get
            {
                return currentCipher;
            }
            set
            {
                currentCipher = value;
                OnPropertyChanged(nameof(CurrentCipher));
            }
        }

        private String answer = String.Empty;
        public override String Answer
        {
            get
            {
                return answer;
            }
            set
            {
                answer = value;
                Hint = CurrentCipher.performConvert(value);
                OnPropertyChanged(nameof(Answer));
            }
        }

        private String cipherType = Utilities.CipherTypes.Morse.ToString();
        public override string CipherType
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

        #endregion

        public MorseCipherViewModel()
        {
           
        }      
    }
}
