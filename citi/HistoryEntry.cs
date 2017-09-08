using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace citi
{
    class HistoryEntry:INotifyPropertyChanged
    {
        private String name;
        private String date;
        private String probability;
        private String comment;
        private MyEntity myEntity;


        public event PropertyChangedEventHandler PropertyChanged;

        public HistoryEntry() {
        }

        public HistoryEntry(String name, String date, String pro, String comment)
        {
            this.name = name;
            this.date = date;
            probability = pro;
            this.comment = comment;
            
        }

        public MyEntity MyEntity { set { myEntity = value; } get { return myEntity; } }


        public HistoryEntry addName(String name)
        {
            this.name = name;
            if (this.PropertyChanged != null)
                this.PropertyChanged.Invoke(this,new PropertyChangedEventArgs("Name"));
            return this;
        }
        public HistoryEntry addDate(String date)
        {
            this.date = date;
            if (this.PropertyChanged != null)
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Date"));
            return this;
        }
        public HistoryEntry addProbability(String probability)
        {
            this.probability = probability;
            if (this.PropertyChanged != null)
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Probability"));
            return this;

        }
        public HistoryEntry addComment(String comment)
        {
            this.comment = comment;
            if (this.PropertyChanged != null)
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Comment"));
            return this;
        }
        

        public String Name { get =>name==null?"null":name; }
        public String Date { get => date==null?"null":date; }
        public String Probability { get => probability == null ? "null" : probability; }
        public String Comment { get => comment == null ? "null" : comment; }


        public override bool Equals(object obj)
        {
            var entry = obj as HistoryEntry;
            return entry != null &&
                   name == entry.name &&
                   date == entry.date &&
                   probability == entry.probability &&
                   comment == entry.comment;
        }

        public override int GetHashCode()
        {
            var hashCode = -605771815;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(date);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(probability);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(comment);
            return hashCode;
        }
    }
}
