using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCypherMaui.Model
{
    public class EncryptModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _key;

        public string Key
        {
            get => _key;
            set
            {
                _key = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Key)));
            }
        }

        private string _plainText;

        public string PlainText
        {
            get => _plainText;
            set
            {
                _plainText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PlainText)));
            }
        }

        private bool _useDate;

        public bool UseDate
        {
            get => _useDate;
            set
            {
                _useDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UseDate)));
            }
        }
    }
}
