using backnc.Data.Interface;

namespace backnc.Service
{
	public class JobService
	{
        private readonly IAppDbContext context;
        public JobService(IAppDbContext context)
        {
            this.context = context; 
        }
    }
}
