namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //sample code

            MuseElf museElf = new MuseElf("Legolas", 69);
            SoulMaster soulMaster = new SoulMaster("KelThuzad", 100);
            BladeKnight bladeKnight = new BladeKnight("Illidan", 10000);

            System.Console.WriteLine(bladeKnight.ToString());
        }
    }
}