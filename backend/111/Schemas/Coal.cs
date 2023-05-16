namespace _111.Schemas
{
    public class Coal
    {
        public int ID { get; set; }
        public int Name { get; set; }
        public string Class { get; set; }
    }

    public class Coals
    {
        public int ID { get; set; }
        public int coal { get; set; }
        public int supplier { get; set; }
        public double coast { get; set;  }
    }

    public class DislayCoal
    {
        public int ID { get; set; }
        public string coal { get; set; }
        public int supplier { get; set; }
        public double coast { get; set; }
    }

    public class Coal_names
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
