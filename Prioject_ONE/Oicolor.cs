using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorPicker_WPF
{
    public class Oicolor : INotifyPropertyChanged
    {
        private string m_ListView_RGB;
        public string ListView_RGB
        {
            get { return m_ListView_RGB; }
            set
            {
                if (m_ListView_RGB != value)
                {
                    m_ListView_RGB = value;
                    Notify("ListView_RGB");
                }
            }
        }

        private string m_ListView_HEX;
        public string ListView_HEX
        {
            get { return m_ListView_HEX; }
            set
            {
                if (m_ListView_HEX != value)
                {
                    m_ListView_HEX = value;
                    Notify("ListView_HEX");
                }
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void Notify(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        #endregion
    }
}
