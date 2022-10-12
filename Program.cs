namespace TPRPGPOO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random aleatoire = new Random();
            int randomEnnemi = aleatoire.Next(10);
            string[] tableauEnnemis = { "Jarod", "Ludo" ,"Piwi", "Julian", "Coco", "Lulu", "Thomix", "Rabah","Patrick", "Sébastien"};
            string randomNameEnnemi = tableauEnnemis[randomEnnemi];
            int randomPdVEnnemi = aleatoire.Next(100,300);
            int randomDegatsEnnemi = aleatoire.Next(10, 30);            
            
            Console.Write("Veuillez choisir un nom pour votre joueur");
            string choixNomJoueur = Console.ReadLine();
            Personnage joueur = new Personnage(choixNomJoueur, 1000, 40);


            
            
            Console.WriteLine(randomNameEnnemi+" est apparu! Vous pouvez ==> [1] : Combattre | [2] : Fuir");
            int entreeChoixActionInitiale = int.Parse(Console.ReadLine());
            if (entreeChoixActionInitiale == 1)
            {
                Ennemi nouvelEnnemi = new Ennemi(randomNameEnnemi, randomPdVEnnemi, randomDegatsEnnemi);
                while (nouvelEnnemi.pointsDeVie > 0 | joueur.pointsDeVie > 0)
                {
                    Console.WriteLine(randomNameEnnemi + " vous toise du regard! Vous pouvez ==> [1] : Combattre ou [2] : Vous soigner");
                    int actionJoueur = int.Parse(Console.ReadLine());
                    if (actionJoueur == 1)
                    {
                        Console.WriteLine("Vous attaquer l'ennemi " + randomNameEnnemi);
                        nouvelEnnemi.defendre(joueur.attaquer());
                        Console.WriteLine(randomNameEnnemi + " possède encore " + nouvelEnnemi.pointsDeVie + " points de vie");
                        Console.WriteLine(randomNameEnnemi + " vous attaque");
                        joueur.defendre(nouvelEnnemi.attaquer());
                        Console.WriteLine("Vous avez "+joueur.pointsDeVie+" points de vie");
                    }
                    else if (actionJoueur == 2)
                    {
                        Console.WriteLine("Vous avez décidé de vous soigner : vous récupérer 100 points de vie.");
                        joueur.soigner(100);
                    }
                    else
                    {
                        Console.WriteLine("Vous devez choisir une action");
                    }
                }
                Console.Write("Vous avez tué " + randomNameEnnemi);

            }
            else if (entreeChoixActionInitiale == 2)
            {
                Console.WriteLine("Les dieux n'aiment pas la lâcheté, vous êtes mort");
            }
            else
            {
                Console.WriteLine("Vous quittez la zone");
            }
            



        }
    }

    internal class Personnage
    {
        static int nombreDeCombats;

        public Personnage(string initNom, int initPdV, int initDegats)
        {
            nom = initNom;
            pointsDeVie = initPdV;
            degats = initDegats;
        }
        public int attaquer()
        {
            nombreDeCombats++;
            return degats;
        }
        public int defendre(int degatsEnnemi)
        {
            return pointsDeVie -= degatsEnnemi;
        }
        public int soigner(int soin)
        {
            return pointsDeVie += soin;
        }
        public string nom { get; set; }
        public int pointsDeVie { get; set; }
        public int degats { get; set; }
        public static int GetnombreDeCombats()
        {
            return nombreDeCombats;
        }
    }

    internal class Ennemi
    {
        public Ennemi(string initNom, int initPdV, int initDegats)
        {
            nom = initNom;
            pointsDeVie = initPdV;
            degats = initDegats;
        }
        public int attaquer()
        {
            return degats;
        }
        public int defendre(int degatsEnnemi)
        {
            return pointsDeVie -= degatsEnnemi;
        }
        public string nom { get; set; }
        public int pointsDeVie { get; set; }
        public int degats { get; set; }
    }


}