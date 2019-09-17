using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchExeTime.DAO.Model
{
    public class WatchExeModel: NotifyPropertyChanged
    {
        private int _ExeID;

        public int ExeID
        {
            get { return _ExeID; }
            set
            {
                _ExeID = value;
                OnPropertyChanged();
            }
        }
        private string _ExeName;

        public string ExeName
        {
            get { return _ExeName; }
            set
            {
                _ExeName = value;
                OnPropertyChanged();
            }
        }
        private string _ExeTitleName;

        public string ExeTitleName
        {
            get { return _ExeTitleName; }
            set
            {
                _ExeTitleName = value;
                OnPropertyChanged();
            }
        }
        private int _IsUsing;

        public int IsUsing
        {
            get { return _IsUsing; }
            set
            {
                _IsUsing = value;
                OnPropertyChanged();
            }
        }
        private int _ParentExeID;

        public int ParentExeID
        {
            get { return _ParentExeID; }
            set
            {
                _ParentExeID = value;
                OnPropertyChanged();
            }
        }
        private string _ExePathName;

        public string ExePathName
        {
            get { return _ExePathName; }
            set
            {
                _ExePathName = value;
                OnPropertyChanged();
            }
        }

    }
}
