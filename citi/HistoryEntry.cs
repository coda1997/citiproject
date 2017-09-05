using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace citi
{
    class HistoryEntry
    {
        private String name;
        private String date;
        private String probability;
        private String comment;

        public HistoryEntry() {
        }
        public HistoryEntry(String name, String date, String pro, String comment) {
            this.name = name;
            this.date = date;
            probability = pro;
            this.comment = comment;
        }

        public HistoryEntry addName(String name)
        {
            this.name = name;
            return this;
        }
        public HistoryEntry addDate(String date)
        {
            this.date = date;
            return this;
        }
        public HistoryEntry addProbability(String probability)
        {
            this.probability = probability;
            return this;

        }
        public HistoryEntry addComment(String comment)
        {
            this.comment = comment;
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
