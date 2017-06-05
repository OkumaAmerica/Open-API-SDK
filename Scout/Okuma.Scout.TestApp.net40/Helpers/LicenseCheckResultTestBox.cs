using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okuma.Scout.TestApp.net40.Helpers
{
    using System.Windows.Controls;
    using System.Windows.Media;


    class LicenseCheckResultTestBox : TextBox
    {
        /// <summary>Color for good result </summary>
        private SolidColorBrush good = Brushes.LimeGreen;

        /// <summary>Color for not as good a result </summary>
        private SolidColorBrush notGood = Brushes.DimGray;

        private SolidColorBrush expired = Brushes.Tomato;

        /// <summary>Color for a bad result </summary>
        private SolidColorBrush bad = Brushes.Firebrick;

        /// <summary>Color for a seriously bad result </summary>
        private SolidColorBrush reallyBad = Brushes.DeepPink;

        /// <summary>
        /// Change the TextBox Foreground (text) color based on its contents
        /// </summary>
        protected override void OnTextChanged(TextChangedEventArgs e)
        { 
            this.Background = Brushes.WhiteSmoke;

            Okuma.Scout.Enums.LicenseStatus thisStatus =
                (Okuma.Scout.Enums.LicenseStatus)Enum.Parse(typeof(Okuma.Scout.Enums.LicenseStatus), this.Text);

            switch (thisStatus)
            {
                case Okuma.Scout.Enums.LicenseStatus.Bad_Key:
                    {
                        this.Foreground = this.bad;
                        break;
                    }

                case Okuma.Scout.Enums.LicenseStatus.Bad_Version:
                    {
                        this.Foreground = this.bad;
                        break;
                    }

                case Okuma.Scout.Enums.LicenseStatus.Critical_Exception:
                    {
                        this.Foreground = this.reallyBad;
                        break;
                    }

                case Okuma.Scout.Enums.LicenseStatus.Expired:
                    {
                        this.Foreground = this.expired;
                        break;
                    }

                case Okuma.Scout.Enums.LicenseStatus.Feature_Not_Found:
                    {
                        this.Foreground = this.notGood;
                        break;
                    }

                case Okuma.Scout.Enums.LicenseStatus.Flexnet_Not_Found:
                    {
                        this.Foreground = this.bad;
                        break;
                    }

                case Okuma.Scout.Enums.LicenseStatus.Insufficient_Version:
                    {
                        this.Foreground = this.bad;
                        break;
                    }

                case Okuma.Scout.Enums.LicenseStatus.Invalid:
                    {
                        this.Foreground = this.bad;
                        break;
                    }

                case Okuma.Scout.Enums.LicenseStatus.Invalid_Machine_Type:
                    {
                        this.Foreground = this.notGood;
                        break;
                    }

                case Okuma.Scout.Enums.LicenseStatus.License_Not_Found:
                    {
                        this.Foreground = this.bad;
                        break;
                    }

                case Okuma.Scout.Enums.LicenseStatus.Valid:
                    {
                        this.Foreground = this.good;
                        break;
                    }
            }

            base.OnTextChanged(e);
        }



    }
}
