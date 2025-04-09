using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Entity
{
    public class Pet
    {
        private String name;
        private int age;
        private String breed;

        public Pet(String name, int age, String breed)
        {
            this.name = name;
            this.age = age;
            this.breed = breed;
        }
        public String getName()
        {
            return name;
        }
        public void setName(String name)
        {
            this.name = name;
        }
        public int getAge()
        {
            return age;
        }
        public void setAge(int age)
        {
            this.age = age;
        }
        public String getBreed()
        {
            return breed;
        }
        public void setBreed(String breed)
        {
            this.breed = breed;
        }
        public String toString()
        {
            return "Pet [Name=" + name + ", Age=" + age + ", Breed=" + breed + "]";
        }

        public class Dog : Pet
        {
            private String DogBreed;

            public Dog(string name, int age, string breed, string dogBreed) : base(name, age, breed)
            {
                this.DogBreed = dogBreed;
            }
            public String getDogBreed()
            {
                return DogBreed;
            }
            public void setBreed(String DogBreed)
            {
                this.DogBreed = DogBreed;
            }

        }

        public class Cat : Pet
        {
            private String CatColor;
            public Cat(string name, int age, string breed, string CatColor) : base(name, age, breed)
            {
                this.CatColor = CatColor;
            }
            public String getColor()
            {
                return CatColor;
            }

        }
    }
}

   