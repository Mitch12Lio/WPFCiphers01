using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFCiphers01.Models;
using WPFCiphers01.Utilities;

namespace WPFCiphers01.ViewModels
{
    public class PolybiusCipherViewModel : CipherViewModel
    {
        #region Properties/Fields

        //for display
        private DataTable? polybiusDT = Algorithms.PolybiusDT;
        public DataTable? PolybiusDT
        {
            get
            {
                return polybiusDT;
            }
            set
            {

                polybiusDT = value;
                OnPropertyChanged(nameof(PolybiusDT));

            }
        }

        private Cipher currentCipher = new PolybiusCipher();
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

        private String cipherType = Utilities.CipherTypes.Polybius.ToString();
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

        public PolybiusCipherViewModel()
        {
            
        }    
    }
}
