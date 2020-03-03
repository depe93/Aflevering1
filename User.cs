using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfOpg
{
    class User:INotifyPropertyChanged
    {
        private int id;
        public int Id
        {
            set
            {
                id = value;
                NotifyPropertyChanged(nameof(id));
                
            }
            get
            {
                return id;
            }
        }       
        
        private int age;
        public int Age
        {
            set
            {
                age = value;
                NotifyPropertyChanged(nameof(age));
                
            }
            get
            {
                return age;
            }
        }
        private int score;
        public int Score
        {
            set
            {
                score = value;
                NotifyPropertyChanged(nameof(score));

            }
            get
            {
                return score;
            }
        }
        private string name;
        public string Name
        {
            set
            {
                name = value;
                NotifyPropertyChanged(nameof(name));

            }
            get
            {
                return name;
            }
        }


        public User(string name, int age, int score, int id)
        {
            this.Name = name;
            this.Age = age;
            this.Score = score;
            this.Id = id;
        }
        public User() { }

        public string ListBoxToString
        {
            get
            {
                return $"{Name}, Id: {Id}";
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
