using System;

namespace tortoisehare {
    internal class RaceAnimal
    {
        public string Name { get; set; }

        char track[70];
        char symbol;
        int position;

        public RaceAnimal(string name)
        {
            Name = name;

        }
    }

    internal class Hare : RaceAnimal

    {

        //Passes the parameter argument from the derived class to

        //the base class constructor.

        public Hare(string name) : base(name)

        {

            //Do something with the child class

        }

    }

    internal class Tortoise : RaceAnimal

    {

        //Passes the parameter argument from the derived class to

        //the base class constructor.

        public Tortoise(string name) : base(name)

        {

            //Do something with the child class

        }

    }

    internal class Race : RaceAnimal
    {

        RaceAnimal winner;
        bool over;
        public Race(string name) : base(name)

        {

            //Do something with the child class
            RaceAnimal animal1;
            RaceAnimal animal2;
            winner = null;
            over = false;

        }
    } }