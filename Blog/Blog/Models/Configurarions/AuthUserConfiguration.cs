using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Models.Configurarions
{
    public class AuthUserConfiguration : IEntityTypeConfiguration<AuthUser>
    {
        public void Configure(EntityTypeBuilder<AuthUser> builder)
        {
            builder
                .Property(x => x.Account) //配置名為Account的屬性
                .HasMaxLength(20) //最大長度限制為20
                .HasColumnType("nvarchar(20)") //指定Account在資料庫的欄位類型為nvarchar(20)
                .HasColumnName("帳號") //資料庫的欄位名稱設為帳號
                .IsRequired(); //Account在資料庫中不能為空值

            builder
                .Property(x => x.Password)
                .HasMaxLength(16) //最大長度限制為16
                .HasColumnType("varchar(16)")
                .HasColumnName("密碼")
                .IsRequired();
        }
    }
}
