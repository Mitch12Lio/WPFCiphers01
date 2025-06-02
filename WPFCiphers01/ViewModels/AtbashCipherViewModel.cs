using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Navigation;
using WPFCiphers01.Models;
using WPFCiphers01.Utilities;

namespace WPFCiphers01.ViewModels
{
    public class AtbashCipherViewModel : CipherViewModel
    {
        #region Properties/Fields

        //for display
        Dictionary<char, char>? atbashDictionary = Algorithms.AtbashDictionary;
        public Dictionary<char, char>? AtbashDictionary
        {
            get
            {
                return atbashDictionary;
            }
            set
            {
                atbashDictionary = value;
                OnPropertyChanged(nameof(AtbashDictionary));
            }
        }


        private Cipher currentCipher = new AtbashCipher();
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

        [Required(ErrorMessage = "Answer is Required")]
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

        private String cipherType = Utilities.CipherTypes.Atbash.ToString();
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

        public AtbashCipherViewModel()
        {
            //Initial Visual
            VisibilityAddButton = Utilities.VisibilityTypes.Visible.ToString();
            VisibilityUpdateButton = Utilities.VisibilityTypes.Hidden.ToString();
        }
    }
}
