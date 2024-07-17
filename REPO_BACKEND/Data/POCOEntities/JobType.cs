using backnc.Service;

namespace backnc.Data.POCOEntities
{
    public class JobType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<UserJobType> UserJobTypes { get; set; }
    }
}
