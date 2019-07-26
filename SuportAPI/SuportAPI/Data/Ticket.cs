using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuportAPI.Data
{
    public enum enStatus : short { New = 0, Open = 1, Pendent = 2, Closed = 3 }
    public enum enType : short { Without = -1, Question = 0, Incident = 1, Problem = 2, Task = 3 }
    public enum enPriority : short { Without = -1, Low = 0, Normal = 1, High = 2, Urgent = 3 }

    [Table("TICKET")]
    public class Ticket : Base
    {
        #region New
        public Ticket()
        {
            this.Id = -1;
            this.Status = enStatus.New;
            this.Type = enType.Without;
            this.Priority = enPriority.Without;
        }
        #endregion

        #region ID
        [Column("ID")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        #endregion
        
        #region Code
        [Column("CODIGO", TypeName = "varchar(50)"), StringLength(50)]
        public string Code { get; set; }
        #endregion

        #region Description
        [Column("DESCRICAO", TypeName = "varchar(100)"), StringLength(100)]
        public string Description { get; set; }
        #endregion

        #region Type
        [Column("TIPO")]
        public short TypeInner { get; set; }

        [NotMapped]
        public enType Type
        {
            get { return (enType)this.TypeInner; }
            set { this.TypeInner = (short)value; }
        }
        #endregion

        #region Priority
        [Column("PRIORIDADE")]
        public short PriorityInner { get; set; }

        [NotMapped]
        public enPriority Priority
        {
            get { return (enPriority)this.PriorityInner; }
            set { this.PriorityInner = (short)value; }
        }
        #endregion

        #region UserId
        [Column("USUARIO_ID")]
        public int UserId { get; set; }
        #endregion

        #region OpeningDate
        [Column("DATA_ABERTURA"), DataType(DataType.Date)]
        public DateTime OpeningDate { get; set; }
        #endregion

        #region ClosingDate
        [Column("DATA_FECHAMENTO"), DataType(DataType.Date)]
        public DateTime? ClosingDate { get; set; }
        #endregion

        #region Status
        [Column("STATUS")]
        public short StatusInner { get; set; }

        [NotMapped]
        public enStatus Status
        {
            get { return (enStatus)this.StatusInner; }
            set { this.StatusInner = (short)value; }
        }
        #endregion
    }
}
