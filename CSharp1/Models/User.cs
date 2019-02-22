using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CSharp1.Models
{
    class User
    {
        
            private DateTime _birtydaydate;
            private int _age;
            private string _westernzodiac;
            private string _chinesezodiac;


            public User(DateTime birtydaydate)
            {
                _birtydaydate = birtydaydate;
                _age = AgeCount();
                _westernzodiac = WesternZodiacCalculate();
                _chinesezodiac = ChineseZodiacCalculate();
            }

            public DateTime BirtyDayDate
            {
                get { return _birtydaydate; }
                private set { _birtydaydate = value; }

            }

            public int AgeCount()
            {
                DateTime today = DateTime.Today;
                int _age = today.Year - _birtydaydate.Year + (_birtydaydate.DayOfYear >= today.DayOfYear?1:0);
                
                if ((_age < 0) || (_age > 135))
                {
                    string message = "Common enter your birthday right";
                    string caption = "It is totally not ok";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxResult result;

                    result = MessageBox.Show(message, caption, button);
                    throw new Exception("You've been caught");
                    
                }
                
            
                

                return _age;
            }

            public int Age
            {
                get { return _age; }
                set { _age = value; }
            }

            public string WesternZodiac
            {
                get { return _westernzodiac; }
                set { _westernzodiac = value; }
            }

            public string ChineseZodiac
            {
                get { return _chinesezodiac; }
                set { _chinesezodiac = value; }
            }


            private string WesternZodiacCalculate()
        {
            switch (_birtydaydate.Month)
            {
                case 1:
                   return _westernzodiac = _birtydaydate.Day <= 19 ? "Capricorn" : "Aquarius";
                    break;
                case 2:
                    return _westernzodiac = _birtydaydate.Day <= 17 ? "Aquarius" : "Pisces";
                    break;
                case 3:
                    return _westernzodiac = _birtydaydate.Day <= 19 ? "Pisces" : "Aries";
                    break;
                case 4:
                    return _westernzodiac = _birtydaydate.Day <= 19 ? "Aries" : "Taurus";
                    break;
                case 5:
                    return _westernzodiac = _birtydaydate.Day <= 20 ? "Taurus" : "Gemini";
                    break;
                case 6:
                    return _westernzodiac = _birtydaydate.Day <= 20 ? "Gemini" : "Cancer";
                    break;
                case 7:
                    return _westernzodiac = _birtydaydate.Day <= 22 ? "Cancer" : "Leo";
                    break;
                case 8:
                    return _westernzodiac = _birtydaydate.Day <= 22 ? "Leo" : "Virgo";
                    break;
                case 9:
                    return _westernzodiac = _birtydaydate.Day <= 22 ? "Virgo" : "Libra";
                    break;
                case 10:
                    return _westernzodiac = _birtydaydate.Day <= 22 ? "Libra" : "Scorpio";
                    break;
                case 11:
                    return _westernzodiac = _birtydaydate.Day <= 21 ? "Scorpio" : "Sagittarius";
                    break;
                case 12:
                   return _westernzodiac = _birtydaydate.Day <= 21 ? "Sagittarius" : "Capricorn";
                    break;
                default:
                    throw new Exception("We haven't invented western Zodiac sign for you yet!");
            }
        }
 

    private string ChineseZodiacCalculate()
        {
            switch (_birtydaydate.Year % 12)
            {
                case 0:
                   return _chinesezodiac = "Monkey";
                    break;
                case 1:
                   return _chinesezodiac = "Rooster";
                    break;
                case 2:
                    return _chinesezodiac = "Dog";
                    break;
                case 3:
                    return _chinesezodiac = "Pig";
                    break;
                case 4:
                    return _chinesezodiac = "Rat";
                    break;
                case 5:
                    return _chinesezodiac = "Ox";
                    break;
                case 6:
                    return _chinesezodiac = "Tiger";
                    break;
                case 7:
                    return _chinesezodiac = "Rabbit";
                    break;
                case 8:
                    return _chinesezodiac = "Dragon";
                    break;
                case 9:
                    return _chinesezodiac = "Snake";
                    break;
                case 10:
                    return _chinesezodiac = "Horse";
                    break;
                case 11:
                    return _chinesezodiac = "Sheep";
                    break;
                default:
                    throw new Exception("Your chinese Zodiac was stolen!");
            }
        }
    }
}
