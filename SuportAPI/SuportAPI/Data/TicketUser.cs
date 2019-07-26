using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuportAPI.Data
{
    [Table("TICKET_USUARIO")]
    public class TicketUser : Base
    {
        #region New
        public TicketUser()
        {
            this.Id = -1;
        }
        #endregion

        #region ID
        [Column("ID")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        #endregion

        #region TicketId
        [Column("TICKET_ID")]
        public int TicketId { get; set; }        
        #endregion

        #region UserId
        [Column("USUARIO_ID")]
        public int UserId { get; set; }        
        #endregion
    }
}
