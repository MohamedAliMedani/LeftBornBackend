using System.ComponentModel.DataAnnotations;
using LeftBornDemoo.Src.Enum;

namespace LeftBornDemoo.Src.Models
{
	public class User : Entity
	{
        public long UserId { get; set; }
        public string? PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string? Email { get; set; }
        public string? ForthName { get; set; }
        public string? ImageUrl { get; set; }

        public State State { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}

