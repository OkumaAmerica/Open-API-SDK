//-----------------------------------------------------------------------
// <copyright file="Subkeys.cs" company="Okuma America Corporation">
//     Copyright© 2016 Okuma America Corporation
// </copyright>
// <project> SCOUT Test Application
// </project>
// <author> Scott Solmer
// </author>   
// <disclaimer> Under no circumstance shall Okuma America be held liable 
// to anyone using this code or programs derived there from for damages 
// of any kind as a result of the use or inability to use this code, 
// including but not limited to damages for loss of goodwill, work 
// stoppage, computer failure or malfunction, or any and all other 
// commercial damages or losses.
// </disclaimer>
//-----------------------------------------------------------------------

namespace ScoutTestApplication
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// This is a custom object that implements the 'PropertyChanged' Event used
    /// for posting the discovered registry subkeys to a DataGridView.
    /// It is designed specifically for listing the SubKeys under the following key:
    /// "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall" thus it includes "DisplayName".
    /// </summary>
    public class Subkeys : INotifyPropertyChanged
    {
        private string _DisplayName;
        private string _Subkey;
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Constructor for Class SubKeys
        /// </summary>
        /// <param name="displayname"></param>
        /// <param name="subkey"></param>
        public Subkeys(string name, string key)
        {
            _DisplayName = name;
            _Subkey = key;
        }

        [DisplayName("Display Name")]
        public string DisplayName
        {
            get { return _DisplayName; }
            set
            {
                _DisplayName = value;
                this.NotifyPropertyChanged("DisplayName");
            }
        }

        [DisplayName("Key")]
        public string Subkey
        {
            get { return _Subkey; }
            set
            {
                _Subkey = value;
                this.NotifyPropertyChanged("Key");
            }
        }

        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
