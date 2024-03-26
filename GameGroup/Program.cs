namespace GameGroup
{
    internal class GameGroup
    {
        public class Game
        {

        }
        public string Title { get; set; }
        public int[] NumberOfPlayers { get; set; }
        public int[] AgeRecommended { get; set; }
        public string[] Categories { get; set; }
        public Game[] ReferenceNumbers { get; set; }
        public float Price { get; set; }
        public float ConditionPrice { get; set; }

        public GameGroup(string title, int[] numberOfPlayers, int[] ageRecommended, string[] categories, Game[] referenceNumbers, float price, float conditionPrice)
        {
            Title = title;
            NumberOfPlayers = numberOfPlayers;
            AgeRecommended = ageRecommended;
            Categories = categories;
            ReferenceNumbers = referenceNumbers;
            Price = price;
            ConditionPrice = conditionPrice;
        }

        public void MemberName()
        {

        }

    }
}
