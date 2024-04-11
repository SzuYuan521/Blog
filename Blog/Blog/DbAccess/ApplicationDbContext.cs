using Microsoft.EntityFrameworkCore;

namespace Blog.DbAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        /// <summary>
        /// 將目前組件中定義的所有實體類型的配置應用到資料庫模型中，這樣就可以在資料庫中建立對應的表格及其詳細定義
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //為每個Table詳細定義內容
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
