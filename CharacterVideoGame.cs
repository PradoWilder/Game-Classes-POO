

namespace CharacterVideoGame
{
    internal class Program
    {

        class Character
        {
            public string Nom;
            public int PointsDeVie;
            public int ForceAttaque;
            public int ForceDefense;

            public Character(string nom, int pointsDeVie, int forceAttaque, int forceDefense)
            {
                Nom = nom;
                PointsDeVie = pointsDeVie;
                ForceAttaque = forceAttaque;
                ForceDefense = forceDefense;
            }
            // Implémentation de la méthode isAlive () qui envoie "true" si "PointsDeVie" est positif et false dans l'autre cas
            public bool isAlive()
            {
                return PointsDeVie > 0;  
            }

            // Implémentation de la méthode "Attack" 
            public void Attack(Character cible)
            {
                cible.PointsDeVie = cible.PointsDeVie - (ForceAttaque - cible.ForceDefense);

                Console.WriteLine($"{Nom} attaque {cible.Nom} avec une force d'attaque de {ForceAttaque} contre une force de défense de {cible.ForceDefense} ");
                Console.WriteLine(" ");
            }
        }

        static void Main(string[] args)
        {
            Character joueur1 = new Character("joueur1", 100, 85, 35);
            Character joueur2 = new Character("joueur2", 50, 45, 25);

            Console.WriteLine($"La bataille a démarré avec :\n{joueur1.PointsDeVie} points de vie pour {joueur1.Nom} contre {joueur2.PointsDeVie} points de vie pour {joueur2.Nom}");
            Console.WriteLine(" ");

            while (joueur1.isAlive() && joueur2.isAlive()) 
            {
                // Attaque du joueur1 contre le joueur2
                joueur1.Attack(joueur2);

                // Ici on va vérifier si la cible est vivante pour afficher le vainqueur
                if (joueur2.isAlive())
                {
                    Console.WriteLine($"{joueur2.Nom} est sorti vainqueur");
                    break;
                }
                else 
                {
                    // Attaque du joueur2 contre le joueur1
                    joueur2.Attack(joueur1);

                    // Ici on va vérifier si la cible est vivante pour afficher le vainqueur
                    if (joueur1.isAlive())
                    {
                        Console.WriteLine($"{joueur1.Nom} est sorti vainqueur");
                        break;
                    } 
                }
            }
        }
    }
}
