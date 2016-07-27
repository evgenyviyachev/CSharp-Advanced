using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_14
{
    class DragonArmy
    {
        static void Main()
        {
            Dictionary<string, SortedDictionary<string, int[]>> typeNameStats = new Dictionary<string, SortedDictionary<string, int[]>>();
            Dictionary<string, int> typeOrder = new Dictionary<string, int>();
            int counter = 1;
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                string[] currentData = Console.ReadLine().Split(' ');
                string type = currentData[0];
                string name = currentData[1];
                int damage = 45;
                int health = 250;
                int armour = 10;
                if (currentData[2] != "null")
                {
                    damage = int.Parse(currentData[2]);
                }
                if (currentData[3] != "null")
                {
                    health = int.Parse(currentData[3]);
                }
                if (currentData[4] != "null")
                {
                    armour = int.Parse(currentData[4]);
                }
                if (!typeNameStats.ContainsKey(type))
                {
                    typeNameStats.Add(type, new SortedDictionary<string, int[]>());
                    typeOrder.Add(type, counter);
                }
                if (!typeNameStats[type].ContainsKey(name))
                {
                    typeNameStats[type].Add(name, new int[3]);
                }
                typeNameStats[type][name][0] = damage;
                typeNameStats[type][name][1] = health;
                typeNameStats[type][name][2] = armour;                
                counter++;
            }
            var types = typeOrder.Keys.OrderBy(x => typeOrder[x]).Select(x => x);
            foreach (var type in types)
            {
                int countOfDragonsSameType = typeNameStats[type].Count;
                double typeDamage = 0;
                double typeHealth = 0;
                double typeArmour = 0;
                foreach (var name in typeNameStats[type].Keys)
                {
                    typeDamage += typeNameStats[type][name][0];
                    typeHealth += typeNameStats[type][name][1];
                    typeArmour += typeNameStats[type][name][2];
                }
                double avgDamage = typeDamage / countOfDragonsSameType;
                double avgHealth = typeHealth / countOfDragonsSameType;
                double avgArmour = typeArmour / countOfDragonsSameType;
                Console.WriteLine($"{type}::({string.Format("{0:0.00}", avgDamage)}/{string.Format("{0:0.00}", avgHealth)}/{string.Format("{0:0.00}", avgArmour)})");
                foreach (var name in typeNameStats[type].Keys)
                {
                    Console.WriteLine($"-{name} -> damage: {typeNameStats[type][name][0]}, health: {typeNameStats[type][name][1]}, armor: {typeNameStats[type][name][2]}");
                }
            }
        }
    }
}