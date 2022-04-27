using System; 
using System.Collections.Generic;using System.Text;

namespace ourwork
{
        class Cinderella
        {
            void Main()
            {
                Builder builder = new ConcreteBuilder();
                Director GodMother = new Director(builder);
                GodMother.Construct();
                MagicProduct mproduct = builder.GetResult();
            }
        }
        class Director
        {
            Builder builder;
            public Director(Builder builder)
            {
                this.builder = builder;
            }
            public void Construct()
            {
                builder.BuildPartA();
                builder.BuildPartB();
                builder.BuildPartC();
            }
        }

        abstract class Builder
        {
            public abstract void BuildPartA();
            public abstract void BuildPartB();
            public abstract void BuildPartC();
            public abstract MagicProduct GetResult();
        }

        class MagicProduct
        {
            List<object> parts = new List<object>();
            public void Add(string part)
            {
                parts.Add(part);
            }
        }

        class ConcreteBuilder : Builder
        {
            MagicProduct mproduct = new MagicProduct();
            public override void BuildPartA()
            {
                mproduct.Add("Part A");
            }
            public override void BuildPartB()
            {
                mproduct.Add("Part B");
            }
            public override void BuildPartC()
            {
                mproduct.Add("Part C");
            }
            public override MagicProduct GetResult()
            {
                return mproduct;
            }
        }
        //платье
        class Dress
        {
            // материал платья
            public string Material { get; set; }
            // цвет платья
            public string Color { get; set; }
        }
        // туфельки
        class Shoes
        {
            public string Material { get; set; }
            public string Size { get; set; }
        }
        // Карета
        class Couch
        {
            public string Worker { get; set; }
            public string Material { get; set; }

        }

        class Ball
        {
            public Dress Dress { get; set; }
            public Shoes Shoes { get; set; }
            public Couch Couch { get; set; }
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();

            if (Dress != null)
            sb.Append("\t Платье!\n Материал платья: " + Dress.Material + "; \n Цвет: " + Dress.Color + ";" + "\n");
                if (Shoes != null)
            sb.Append("\n\t Туфли!\n Материал туфелек: " + Shoes.Material + "; \n Размер: " + Shoes.Size + ";" +"\n");
                if (Couch != null)
            sb.Append("\n\t Карета!\n Материал кареты: " + Couch.Material + "; \n Экипаж кареты: " + Couch.Worker + ";"+ "\n");
                return sb.ToString();
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(" Собираем Золушку на бал!\n");
                Fairy fairy = new Fairy();
                BallBuilder builder = new WheatBallBuilder();
                Ball wheatBall = fairy.Fair(builder);
                Console.WriteLine(wheatBall.ToString());

                Console.Read();
            }
        }
        abstract class BallBuilder
        {
            public Ball Ball { get; private set; }
            public void CreateBall()
            {
                Ball = new Ball();
            }
            public abstract void SetDress();
            public abstract void SetShoes();
            public abstract void SetCouch();
        }
        class Fairy
        {
            public Ball Fair(BallBuilder ballBuilder)
            {
                ballBuilder.CreateBall();
                ballBuilder.SetDress();
                ballBuilder.SetShoes();
                ballBuilder.SetCouch();
                return ballBuilder.Ball;
            }
        }


        class WheatBallBuilder : BallBuilder
        {
            public override void SetDress()
            {
                this.Ball.Dress = new Dress { Material = "серпантин", Color = "голубой" };
            }

            public override void SetShoes()
            {
                this.Ball.Shoes = new Shoes { Material = "хрусталь", Size = "6 дюймов" };
            }

            public override void SetCouch()
            {
                this.Ball.Couch = new Couch { Material = "тыква", Worker = "мыши, крысы, ящерицы", };
            }
        }
    }