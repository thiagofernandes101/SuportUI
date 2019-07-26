using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SuportAPI.Data
{
    public enum enUserType : short { Suport = 0, Client = 1 }

    [Table("USUARIO")]
    public class User : Base
    {
        #region New
        public User()
        {
            this.Id = -1;            
        }
        #endregion

        #region ID
        [Column("ID")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        #endregion

        #region Name
        [Column("NOME", TypeName = "varchar(50)"), StringLength(50)]
        public string Name { get; set; }
        #endregion

        #region Company
        [Column("EMPRESA", TypeName = "varchar(100)"), StringLength(100)]
        public string Company { get; set; }
        #endregion

        #region Login
        [Column("USUARIO", TypeName = "varchar(50)"), StringLength(50)]
        public string Login { get; set; }
        #endregion

        #region Password
        [Column("SENHA", TypeName = "varchar(50)"), StringLength(50)]
        public string Password { get; set; }
        #endregion

        #region Type
        [Column("TIPO")]
        public short TypeInner { get; set; }

        [NotMapped]
        public enUserType Type
        {
            get { return (enUserType)this.TypeInner; }
            set { this.TypeInner = (short)value; }
        }
        #endregion        
    }
}
