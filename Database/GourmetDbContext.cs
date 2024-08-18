using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class GourmetDbContext : DbContext
    {
        // 依存性の注入用コンストラクタ
        public GourmetDbContext(DbContextOptions<GourmetDbContext> options) : base(options) { }

        // エンティティ定義（作成したエンティティと名前が揃うように設定）
        public DbSet<Gourmet> Gourmet { get; set; }
        public DbSet<Prefecture> Prefecture { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* エンティティの追加設定など */
        }
    }
}
