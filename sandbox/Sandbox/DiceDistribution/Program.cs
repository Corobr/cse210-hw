namespace DiceDistribution;

class Program
{
    static void Main(string[] args)
    {
        List<int> tallies = new List<int>();
        PrepareTallyList(tallies);

        int experiments = 1000000;
        ThrowLotsOfDice(tallies, experiments);

        DisplayResults(tallies, experiments);
    }
}
