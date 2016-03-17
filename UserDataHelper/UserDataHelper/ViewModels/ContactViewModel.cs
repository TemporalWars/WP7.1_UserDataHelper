using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Windows.Media;
using Microsoft.Phone.UserData;

namespace BenScharbach.WP7.Helpers.UserData.ViewModels
{
    /// <summary>
    ///  //  [Serializable]
    /// </summary>
    /// <remarks>
    /// The use of WCF DataContract / DataMember attributes for WP7 IsolatedStorage Serialization;
    /// http://www.codeproject.com/Articles/156254/Simple-Data-Serializatoin-on-WP/
    /// </remarks>
    [DataContract]
    public class ContactViewModel : INotifyPropertyChanged
    {
        private string _contactName;
        private Brush _contactColor = new SolidColorBrush(Colors.Blue);

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string ContactName
        {
            get
            {
                return _contactName;
            }
            set
            {
                if (value != _contactName)
                {
                    _contactName = value;
                    NotifyPropertyChanged("ContactName");
                }
            }
        }
        
        /// <summary>
        /// 
        /// </summary>        
        public Brush ContactColor
        {
            get
            {
                return _contactColor;
            }
            set
            {
                if (value != _contactColor)
                {
                    _contactColor = value;
                    NotifyPropertyChanged("ContactColor");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Contact ContactItem { get; set; }

        #region INotify
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        } 
        #endregion
    }
}
