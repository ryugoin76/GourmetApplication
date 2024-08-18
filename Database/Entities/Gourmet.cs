using System.ComponentModel.DataAnnotations;

namespace Database.Entities
{
    public class Gourmet
    {
        /// <summary>
        /// グルメID
        /// </summary>
        [Key]
        public int GourmetId { get; set; }

        /// <summary>
        /// グルメ名
        /// </summary>
        [MaxLength(100)]
        public required string GourmetName { get; set; }

        /// <summary>
        /// 県コード
        /// </summary>
        public int PrefectureCode { get; set; }

        /// <summary>
        /// 評価
        /// </summary>
        public int? Rate { get; set; }
    }
}
