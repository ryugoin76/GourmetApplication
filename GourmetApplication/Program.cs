using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

// �ݒ�t�@�C������ݒ�l���擾
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

// Add services to the container.
builder.Services.AddControllersWithViews();

// �Z�b�V�����g�p�̂��ߒǉ�
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


// DB�R���e�L�X�g�N���X�́u�ˑ����̒����v���s���A�}�C�O���[�V�����Ɏg�p����ڑ��������ݒ�
builder.Services.AddDbContext<GourmetDbContext>(options => {
    options.UseSqlServer(config.GetConnectionString(nameof(GourmetDbContext)));
});

// ���O�o�͂�ǉ�
//builder.Services.AddHttpLogging(option => { });
builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields =
        HttpLoggingFields.RequestProperties | HttpLoggingFields.ResponsePropertiesAndHeaders;
    
});


var app = builder.Build();

app.UseHttpLogging();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// �Z�b�V�����g�p�̂��ߒǉ�
app.UseSession();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Ramen}/{action=Index}");

app.Run();
