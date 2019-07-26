using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuportAPI.Data
{
    public enum enRowStatus : short { Removed = -1, Temporary = 0, Active = 1 }

    public class Base
    {
        #region New
        public Base()
        {
            this.RowDate = DateTime.Now;
            this.RowStatus = enRowStatus.Temporary;
        }
        #endregion

        #region RowDate

        [Column("BASEROWD"), Required, DataType(DataType.Date)]
        public DateTime RowDate { get; set; }

        #endregion

        #region RowStatus
        [Column("BASEROWS"), Required]
        public short RowStatusValue { get; set; }

        [NotMapped]
        public enRowStatus RowStatus
        {
            get { return (enRowStatus)this.RowStatusValue; }
            set { this.RowStatusValue = (short)value; }
        }
        #endregion
    }
}
