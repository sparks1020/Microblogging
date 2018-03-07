using System;
namespace Microblogging.Models
{
    public class Follow
    {
        public int Id { get; set; }

        public int Following { get; set; }
        public int Followers { get; set; }

		public static implicit operator int(Follow v)
		{
			throw new NotImplementedException();
		}
	}
}
