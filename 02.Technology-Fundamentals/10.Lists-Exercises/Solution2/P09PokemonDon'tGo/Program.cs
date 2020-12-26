using System;
using System.Collections.Generic;
using System.Linq;

namespace P09PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemons = Console.ReadLine().Split().Select(int.Parse).ToList();
            
            int sum = 0;
            while (pokemons.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                int value = 0;
                if (index < 0)
                {
                    value = pokemons[0];
                    sum += value;
                    pokemons[0] = pokemons[pokemons.Count - 1];
                    for (int i = 0; i < pokemons.Count; i++)
                    {

                        if (pokemons[i] <= value)
                        {
                            pokemons[i] += value;
                        }
                        else if (pokemons[i] > value)
                        {
                            pokemons[i] -= value;
                        }

                    }
                }
                else if (index > pokemons.Count - 1)
                {
                    value = pokemons[pokemons.Count - 1];
                    sum += value;
                    pokemons[pokemons.Count - 1] = pokemons[0];
                    for (int i = 0; i < pokemons.Count; i++)
                    {

                        if (pokemons[i] <= value)
                        {
                            pokemons[i] += value;
                        }
                        else if (pokemons[i] > value)
                        {
                            pokemons[i] -= value;
                        }

                    }
                }
                
                else
                {
                    value = pokemons[index];
                    sum += value;
                    pokemons.RemoveAt(index);
                    for (int i = 0; i < pokemons.Count; i++)
                    {
                        
                        if (pokemons[i] <= value)
                        {
                            pokemons[i] += value;
                        }
                        else if (pokemons[i] > value)
                        {
                            pokemons[i] -= value;
                        }
                        
                    }
                    
                }
                
            }
            Console.WriteLine(sum);
        }
    }
}
