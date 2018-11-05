using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NLayerMovie.DAL.Entities
{
    public class CommentEntity
    {
        [Key]
        [ForeignKey("Comment")]
        public int ID { get; set; }
        public string userID { get; set; }

        public int entityID { get; set; }
        public int entityType { get; set; }

        public virtual ClientProfile user { get; set; }
        public virtual Comment Comment{ get; set; }

    }
}
