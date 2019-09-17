using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WatchExeTime.DAO.Model
{
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
