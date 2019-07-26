using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuportAPI.Data
{
    [Table("COMENTARIO")]
    public class Comments : Base
    {
        #region New
        public Comments()
        {
            this.Id = -1;
        }
        #endregion

        #region ID
        [Column("ID")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        #endregion

        #region TicketUserId
        [Column("TICKET_USUARIO_ID")]
        public int TicketUserId { get; set; }        
        #endregion

        #region Comment
        [Column("COMENTARIO", TypeName = "varchar(4000)"), StringLength(4000)]
        public string Comment { get; set; }
        #endregion

    }
}
