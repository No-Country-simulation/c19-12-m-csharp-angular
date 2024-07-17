using backnc.Service;

namespace backnc.Data.POCOEntities
{
    public class StoryList
    {
        public int Id { get; set; }
        public int UserJobTypeId { get; set; }
        public string Name { get; set; }

        public UserJobType UserJobType { get; set; }
        public ICollection<Story> Stories { get; set; }
    }
}
