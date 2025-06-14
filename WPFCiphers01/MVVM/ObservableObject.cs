﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFCiphers01.MVVM
{
    //public abstract class ObservableObject : INotifyPropertyChanged, INotifyDataErrorInfo
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        //Dictionary<string, List<string>> Errors = new Dictionary<string, List<string>>();
        //public bool HasErrors => Errors.Count > 0;

        //public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
        //public IEnumerable GetErrors(string? propertyName)
        //{
        //    if (Errors.ContainsKey(propertyName))
        //    {
        //        return Errors[propertyName];
        //    }
        //    else { return Enumerable.Empty<string>(); }
        //}

        //public void Validate(string propertyName, object propertyValue)
        //{
        //    var results = new List<ValidationResult>();
        //    Validator.TryValidateProperty(propertyValue, new ValidationContext(this) { MemberName = propertyName }, results);
        //    if (results.Any())
        //    {
        //        Errors.Add(propertyName, results.Select(r => r.ErrorMessage).ToList());
        //        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        //    }
        //    else
        //    {
        //        Errors.Remove(propertyName);
        //        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        //    }


        //}

        #region Debugging Aides

        /// <summary>
        /// Warns the developer if this object does not have
        /// a public property with the specified name. This 
        /// method does not exist in a Release build.
        /// </summary>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public virtual void VerifyPropertyName(string propertyName)
        {
            // Verify that the property name matches a real,  
            // public, instance property on this object.
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name: " + propertyName;

                if (this.ThrowOnInvalidPropertyName)
                    throw new Exception(msg);
                else
                    Debug.Fail(msg);
            }
        }

        /// <summary>
        /// Returns whether an exception is thrown, or if a Debug.Fail() is used
        /// when an invalid property name is passed to the VerifyPropertyName method.
        /// The default value is false, but subclasses used by unit tests might 
        /// override this property's getter to return true.
        /// </summary>
        protected virtual bool ThrowOnInvalidPropertyName { get; private set; }



        #endregion // Debugging Aides

        #region INotifyPropertyChanged Members

        /// <summary>
        /// Raises the PropertyChange event for the property specified
        /// </summary>
        /// <param name="propertyName">Property name to update. Is case-sensitive.</param>
        public virtual void RaisePropertyChanged(string propertyName)
        {
            this.VerifyPropertyName(propertyName);
            OnPropertyChanged(propertyName);
        }

        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.VerifyPropertyName(propertyName);

            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }



        #endregion // INotifyPropertyChanged Members
    }
}
