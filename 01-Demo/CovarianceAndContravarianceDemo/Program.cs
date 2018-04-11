using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovarianceAndContravarianceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //协变 public interface IEnumerable<out T> : IEnumerable
            IEnumerable<Dog> dogs = new List<Dog>();
            IEnumerable<Animal> animals = dogs;

            //逆变 public delegate void Action<in T>(T obj);
            Action<Animal> actionAnimal = a =>
            {
                /*让动物叫*/
            };

            Action<Dog> actionDog = actionAnimal;
            actionDog(new Dog());
        }
    }
}
