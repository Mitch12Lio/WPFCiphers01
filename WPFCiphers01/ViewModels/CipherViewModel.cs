using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using WPFCiphers01.Models;
using WPFCiphers01.MVVM;

namespace WPFCiphers01.ViewModels
{
    public abstract class CipherViewModel : ObservableObject
    {

        #region Properties/Fields

        public abstract Cipher CurrentCipher { get; set; }   
        

        private string visibilityAddButton = Utilities.VisibilityTypes.Visible.ToString();
        public string VisibilityAddButton
        {
            get
            {
                return visibilityAddButton;
            }
            set
            {
                visibilityAddButton = value;
                OnPropertyChanged(nameof(VisibilityAddButton));
            }
        }

        private string visibilityUpdateButton = Utilities.VisibilityTypes.Hidden.ToString();
        public string VisibilityUpdateButton
        {
            get
            {
                return visibilityUpdateButton;
            }
            set
            {
                visibilityUpdateButton = value;
                OnPropertyChanged(nameof(VisibilityUpdateButton));
            }
        }


        private String answer = String.Empty;

        [Required(ErrorMessage = "Answer is Required")]
        public virtual String Answer
        {
            get
            {
                return CurrentCipher.Answer;
            }
            set
            {
                CurrentCipher.Answer = value;
                Hint = CurrentCipher.performConvert(value);
                OnPropertyChanged(nameof(Answer));
            }
        }

        private String hint = String.Empty;

        [Required(ErrorMessage = "Cipher is Required")]
        public String Hint
        {
            get
            {
                return hint;
            }
            set
            {
                hint = value;
                //Validate(nameof(Hint), value);
                OnPropertyChanged(nameof(Hint));
            }
        }

        public abstract String CipherType { get; set; }

        public virtual CipherLocation? Location { get; set; }

        #endregion
    }
}
