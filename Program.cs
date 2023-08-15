using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns20230211_Flyweight
{
    // ДЗ от 2023 02 11, задание 2
    // 2. Розібрати та реалізувати паттерн Flyweight
    // (https://refactoring.guru/uk/design-patterns/flyweight)

    // Flyweight: интерфейс для общих свойств воина
    interface IWarrior
    {
        void Display(int x, int y);
    }

    // ConcreteFlyweight: реализация общих свойств воина
    class Warrior : IWarrior
    {
        private string _type;
        private string _weapon;
        private string _armor;

        public Warrior(string type, string weapon, string armor)
        {
            _type = type;
            _weapon = weapon;
            _armor = armor;
        }

        public void Display(int x, int y)
        {
            Console.WriteLine($"{_type} warrior with {_weapon} and {_armor} is displayed at coordinates ({x}, {y})");
        }
    }

    // FlyweightFactory: фабрика для управления общими воинами
    class WarriorFactory
    {
        // поле, в котором хранится коллекция воинов
        private Dictionary<string, IWarrior> _warriorTypes = new Dictionary<string, IWarrior>();

        // принимает характиристики воина, проверяет есть ли воин с такими характеристиками,
        // если есть - возвращает его,
        // если нет - создаёт
        public IWarrior GetWarriorType(string type, string weapon, string armor)
        {
            string key = $"{type}-{weapon}-{armor}";
            if (_warriorTypes.ContainsKey(key))
            {
                return _warriorTypes[key];
            }
            else
            {
                IWarrior warrior = new Warrior(type, weapon, armor);
                _warriorTypes[key] = warrior;
                return warrior;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            WarriorFactory warriorFactory = new WarriorFactory();

            // Создание воинов с разными характеристиками и их отображение на экране
            IWarrior knightSwordArmor = warriorFactory.GetWarriorType("KNIGHT", "SWORD", "ARMOR");
            knightSwordArmor.Display(10, 20);

            IWarrior archerBowNoArmor = warriorFactory.GetWarriorType("ARCHER", "BOW & ARROWS", "NO ARMOR");
            archerBowNoArmor.Display(30, 40);

            // Повторное использование того же типа воина с разными характеристиками
            IWarrior anotherKnightSwordArmor = warriorFactory.GetWarriorType("KNIGHT", "SQORD", "ARMOR");
            anotherKnightSwordArmor.Display(50, 60);
        }
    }
}
