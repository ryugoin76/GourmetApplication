using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    public class Prefecture
    {
        /// <summary>
        /// 県コード
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PrefectureCode { get; set; }

        /// <summary>
        /// 県名
        /// </summary>
        [MaxLength(100)]
        public required string PrefectureName { get; set; }
    }
}
