using System.ComponentModel;
using System.Diagnostics.Metrics;


/*Program Author: Amber McDowell

MSU NetID: w10056384

Assignment: Tortoise and the Hare

Description:

program that simulates the race from the classic aesop about the tortoise and the hare.

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tortoisehare {
    internal abstract class RaceAnimal
    {
        public string Name { get; set; }

        private char[] track = new char[70];
        private char symbol;
        private int position;

        public RaceAnimal(string name, char letter)
        {
            Name = name;
            symbol = letter;
            position = 0;
            for (int i = 0; i < track.Length; i++)
            {
                track[i] = '-';
                
            }

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < track.Length; i++)
            {
                if (i == position)
                {
                    track[i] = symbol;
                }
                else { track[i] = '-'; }
                sb.Append(track[i]);
            }
            return sb.ToString();
        }
        protected void ChangePos(int move)
        {
            if (position + move >= 0 && position + move <= 69)
            {
                position = position + move;
            }
            else if (position + move < 0)
            { position = 0; }
            else if (position + move > 69)
            {
                position = 69;

            }
        }
        public abstract void Move();
    }

    internal class Hare : RaceAnimal

    {

        //Passes the parameter argument from the derived class to

        //the base class constructor.

        public Hare(string name, char letter) : base(name, letter)

        {

            

        }
        public override void Move()
        {
            Random randomNumbers = new Random();
            int move = randomNumbers.Next(1, 11);
            int number = 0;
            if (move >= 1 && move <= 2)
            {
                number = 0;
            }
            else if (move >= 3 && move <= 4)
            {
                number = 9;
            }
            else if (move == 5)
            {
                number = -12;
            }
            else if (move >= 6 && move <= 8)
            {
                number = 1;
            }
            else if (move >= 9 && move <= 10)
            {
                number = -2;
            }
            ChangePos(number);

        }
    }

    internal class Tortoise : RaceAnimal

    {

        //Passes the parameter argument from the derived class to

        //the base class constructor.

        public Tortoise(string name, char letter) : base(name, letter)

        {

            //Do something with the child class

        }
        public override void Move()
        {
            Random randomNumbers = new Random();
            int move = randomNumbers.Next(1, 11);
            int number =0;
            if (move >= 1 && move <= 5)
            {
                number = 3;
            }
            else if (move >= 6 && move <= 7)
            {
                number = -6;
            }
            else if (move >= 8 && move <= 10)
            {
                number = 1;
            }
            ChangePos(number);
        }
    }

    internal class Race
    {
        RaceAnimal animal1 = new Tortoise("Tortoise", 't');
        RaceAnimal animal2 = new Hare("Hare", 'h');
        RaceAnimal winner;
        bool over;
        public Race()

        {
            winner = null;
            over = false;
        }
        public bool UpdateStatus(int index1, int index2)
        {

            if (index1 == 69 && index2 == 69)
            {

                winner = null;
                return true;
            }
            else if (index1 == 69)
            {
                winner = animal1;
                return true;
            }
            else if (index2 == 69)
            {
                winner = animal2;
                return true;
            }
            else { return false; }

        }
        public void simulate()
        {

            Console.WriteLine(animal1.ToString());
            Console.WriteLine(animal2.ToString());
            while (over != true)
            {
                Thread.Sleep(1000);

                Console.Clear();
                animal1.Move();
                animal2.Move();

                Console.WriteLine(animal1.ToString());
                Console.WriteLine(animal2.ToString());

                
                over = UpdateStatus(animal1.ToString().IndexOf("t"), 
                animal2.ToString().IndexOf("h"));
            }
            Console.WriteLine($"The {winner.Name} won the race!" );
        }
    } 
}