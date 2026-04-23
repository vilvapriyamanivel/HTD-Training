namespace Assessment4
{
    public class Distance
    {
        public int Kilometer { get; set; }

        public static Distance Add(Distance d1, Distance d2)
        {
            return new Distance
            {
                Kilometer = d1.Kilometer + d2.Kilometer
            };
        }

        public string Display()
        {
            return $"Total Distance : {Kilometer} km";
        }
    }
}
