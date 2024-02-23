using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LeftBornDemoo.Src.Enum;

namespace LeftBornDemoo.Src.Models
{
	public class Entity
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public long Id { get; set; }
        public DateTime CreatedOn { get; set; }

        [ForeignKey("User")]
        public long? CreatedBy { get; set; }
        public User User { get; set; }

        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public State State { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}

